using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerBasicMovement : MonoBehaviour {

	public Vector3 dist;
	public float distancia;
	public int SegVel;
	
	public float walkSpeed = 0.15f;
	public float runSpeed = 1.0f;
	public float sprintSpeed = 2.0f;
	
	
	public float turnSmoothing = 3.0f;
	public float aimTurnSmoothing = 15.0f;
	public float speedDampTime = 0.1f;
	
	public float jumpHeight = 150.0f;
	public float jumpCooldown = 1.0f;
	
	private float timeToNextJump = 0;
	
	private float speed;
	
	private Vector3 lastDirection;
	
	private Animator anim;
	private int speedFloat;
	private int hFloat;
	private int vFloat;
	private int aimBool;
	private int groundedBool;
	public Transform cameraTransform;
	
	private float h;
	private float v;
	
	private bool aim;
	
	private bool run;
	private bool sprint;
	
	private bool isMoving;
	
	
	private float distToGround;
	private float sprintFactor;
	
	void Awake()
	{
		anim = GetComponent<Animator> ();
		//cameraTransform = Camera.main.transform;
		cameraTransform = GameObject.Find ("Main Camera Game").transform;

		speedFloat = Animator.StringToHash("Speed");
		hFloat = Animator.StringToHash("H");
		vFloat = Animator.StringToHash("V");
		aimBool = Animator.StringToHash("Aim");
		groundedBool = Animator.StringToHash("Grounded");
		distToGround = GetComponent<Collider>().bounds.extents.y;
		sprintFactor = sprintSpeed / runSpeed;
	}
	
	bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		aim = Input.GetButton("Aim");
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");
		run = Input.GetButton ("Run");
		sprint = Input.GetButton ("Sprint");
		isMoving = Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1;
	}
	void FixedUpdate()
	{
		anim.SetBool (aimBool, IsAiming());
		anim.SetFloat(hFloat, h);
		anim.SetFloat(vFloat, v);
		
		anim.SetBool (groundedBool, IsGrounded ());
		
		MovementManagement (h, v, run, sprint);
		JumpManagement ();	
	}

	void JumpManagement()
	{
		if (Input.GetButtonDown ("Jump"))
		{
			anim.SetTrigger("Jump");
			if(speed > 0 && timeToNextJump <= 0 && !aim)
			{
				GetComponent<Rigidbody>().velocity = new Vector3(0, jumpHeight, 0);
				timeToNextJump = jumpCooldown;
			}
			GetComponent<Rigidbody>().AddForce (new Vector3 (0,10000f,0)*Time.deltaTime);
		}
	}
	void MovementManagement(float horizontal, float vertical, bool running, bool sprinting)
	{

		Rotating(horizontal, vertical);
		
		if(isMoving)
		{
			if(sprinting)
			{
				speed = sprintSpeed;
			}
			else if (running)
			{
				speed = runSpeed;
			}
			else
			{
				speed = walkSpeed;
			}
			
			anim.SetFloat(speedFloat, speed, speedDampTime, Time.deltaTime);
		}
		else
		{
			speed = 0f;
			anim.SetFloat(speedFloat, 0f);
		}
		GetComponent<Rigidbody>().AddForce(Vector3.forward*speed);
	}
	
	Vector3 Rotating(float horizontal, float vertical)
	{

		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0.0f;
		forward = forward.normalized;
		
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		
		Vector3 targetDirection;
		
		float finalTurnSmoothing;
		
		if(IsAiming() && SceneManager.GetActiveScene().name == "Cena1")
		{
			targetDirection = forward;
			finalTurnSmoothing = aimTurnSmoothing;
		}
		else
		{
			targetDirection = forward * vertical + right * horizontal;
			finalTurnSmoothing = turnSmoothing;
		}
		
		if((isMoving && targetDirection != Vector3.zero) || IsAiming())
		{
			Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
			
			Quaternion newRotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, targetRotation, finalTurnSmoothing * Time.deltaTime);
			GetComponent<Rigidbody>().MoveRotation (newRotation);
			lastDirection = targetDirection;
		}
		if(!(Mathf.Abs(h) > 0.9 || Mathf.Abs(v) > 0.9))
		{
			Repositioning();
		}
		
		return targetDirection;
	}	
	
	private void Repositioning()
	{
		Vector3 repositioning = lastDirection;
		if(repositioning != Vector3.zero)
		{
			repositioning.y = 0;
			Quaternion targetRotation = Quaternion.LookRotation (repositioning, Vector3.up);
			Quaternion newRotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);
			GetComponent<Rigidbody>().MoveRotation (newRotation);
		}
	}
	public bool IsAiming()
	{
		return aim;
	}
	
	public bool isSprinting()
	{
		return sprint && !aim && (isMoving);
	}
}
