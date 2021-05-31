using UnityEngine;
using System.Collections;

public class ThirdPersonOrbitCam : MonoBehaviour 
{
	public GameObject DorothyPlay;
	public GameObject TotoPlay;
	public GameObject EspantalhoPlay;
	public GameObject HomemLataPlay;

	public GameObject disparo_magico;
	public GameObject mira;

	public Transform player1;
	public Transform player2;
	public Transform player3;
	public Transform player4;
	public Transform playerAtual;
	public int DefinePlayer;


	//Variaveis para receber as Posiçoes dos personagens 
	public Texture2D crosshair;
	
	public Vector3 pivotOffset;
	public Vector3 camOffset;

	public float smooth = 10f;

	public Vector3 aimPivotOffset = new Vector3(0.0f, 1.7f,  -0.3f);
	public Vector3 aimCamOffset   = new Vector3(0.8f, 0.0f, -1.0f);

	public float horizontalAimingSpeed = 400f;
	public float verticalAimingSpeed = 400f;
	public float maxVerticalAngle = 30f;
	public float flyMaxVerticalAngle = 60f;
	public float minVerticalAngle = -60f;
	
	public float mouseSensitivity = 0.3f;

	public float sprintFOV = 100f;
	
	private PlayerControl playerControl;
	private PlayerBasicMovement PlayerBasic;
	private float angleH = 0;
	private float angleV = 0;
	private Transform cam;

	private Vector3 relCameraPos;
	private float relCameraPosMag;
	
	private Vector3 smoothPivotOffset;
	private Vector3 smoothCamOffset;
	private Vector3 targetPivotOffset;
	private Vector3 targetCamOffset;

	private float defaultFOV;
	private float targetFOV;




	void FixedUpdate(){
		if (DefinePlayer == 0) {

			PlayerControl.PlayerON = 1;
			PlayerControlDog.PlayerON = 2;
			PlayerControlEspantalho.PlayerON = 2;
			PlayerControlHMDL.PlayerON = 2;
			playerAtual = player1;
		}
		if (DefinePlayer == 1) {
			PlayerControlDog.PlayerON = 1;
			PlayerControl.PlayerON = 2;
			PlayerControlEspantalho.PlayerON = 2;
			PlayerControlHMDL.PlayerON = 2;
			playerAtual = player2;
		}
		if (DefinePlayer == 2) {
			PlayerControlEspantalho.PlayerON = 1;
			PlayerControlDog.PlayerON = 2;
			PlayerControl.PlayerON = 2;
			PlayerControlHMDL.PlayerON = 2;
			playerAtual = player3;
		}
		if (DefinePlayer == 3) {
			PlayerControlEspantalho.PlayerON = 2;
			PlayerControlDog.PlayerON = 2;
			PlayerControl.PlayerON = 2;
			PlayerControlHMDL.PlayerON = 1;
			playerAtual = player4;
		}
	}
	void Update(){
		pivotOffset = new Vector3(0.51f, 0.65f,  0.0f);
		camOffset   = new Vector3(0.0f, 1.6f, -5.26f);
		Debug.LogWarning (pivotOffset + camOffset);

		if (Input.GetKey (KeyCode.Alpha1)&& playerAtual != player1) {
			DefinePlayer = 0;
		}
		if (Input.GetKey (KeyCode.Alpha2)&& playerAtual != player2) {
			DefinePlayer = 1;
		}
		if (Input.GetKey (KeyCode.Alpha3)&& playerAtual != player3) {
			DefinePlayer = 2;
		}
		if (Input.GetKey (KeyCode.Alpha4)&& playerAtual != player4) {
			DefinePlayer = 3;
		}
		if (DefinePlayer == 0 && Input.GetKeyDown (KeyCode.Mouse0) && PlayerBasic.IsAiming()) {
			
			Instantiate (disparo_magico, new Vector3 (mira.transform.position.x, mira.transform.position.y, mira.transform.position.z), mira.transform.rotation);
			
		}
	}
	void Awake()
	{
		playerAtual = player1;

		cam = transform;
		PlayerBasic = playerAtual.GetComponent<PlayerBasicMovement> ();

		relCameraPos = transform.position - playerAtual.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;

		smoothPivotOffset = pivotOffset;
		smoothCamOffset = camOffset;

		defaultFOV = cam.GetComponent<Camera>().fieldOfView;

	}
	
	void LateUpdate()
	{
		angleH += Mathf.Clamp(Input.GetAxis("Mouse X"), -1, 1) * horizontalAimingSpeed * Time.deltaTime;
		angleV += Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 1) * verticalAimingSpeed * Time.deltaTime;

			angleV = Mathf.Clamp(angleV, minVerticalAngle, maxVerticalAngle);
		


		Quaternion aimRotation = Quaternion.Euler(-angleV, angleH, 0);
		Quaternion camYRotation = Quaternion.Euler(0, angleH, 0);
		cam.rotation = aimRotation;

		if(PlayerBasic.IsAiming())
		{
			targetPivotOffset = aimPivotOffset;
			targetCamOffset = aimCamOffset;
		}
		else
		{
			targetPivotOffset = pivotOffset;
			targetCamOffset = camOffset;
		}

		if(PlayerBasic.isSprinting())
		{
			targetFOV = sprintFOV;
		}
		else
		{
			targetFOV = defaultFOV;
		}
		cam.GetComponent<Camera>().fieldOfView = Mathf.Lerp (cam.GetComponent<Camera>().fieldOfView, targetFOV,  Time.deltaTime);

		// Test for collision
		Vector3 baseTempPosition = playerAtual.position + camYRotation * targetPivotOffset;
		Vector3 tempOffset = targetCamOffset;
		for(float zOffset = targetCamOffset.z; zOffset < 0; zOffset += 0.5f)
		{
			tempOffset.z = zOffset;
			if(DoubleViewingPosCheck(baseTempPosition + aimRotation * tempOffset))
			{
				targetCamOffset.z = tempOffset.z;
				break;
			}
		}


		smoothPivotOffset = Vector3.Lerp(smoothPivotOffset, targetPivotOffset, smooth * Time.deltaTime);
		smoothCamOffset = Vector3.Lerp(smoothCamOffset, targetCamOffset, smooth * Time.deltaTime);

		cam.position =  playerAtual.position + camYRotation * smoothPivotOffset + aimRotation * smoothCamOffset;

	}

	// concave objects doesn't detect hit from outside, so cast in both directions
	bool DoubleViewingPosCheck(Vector3 checkPos)
	{
		return ViewingPosCheck (checkPos) && ReverseViewingPosCheck (checkPos);
	}

	bool ViewingPosCheck (Vector3 checkPos)
	{
		RaycastHit hit;
		
		// If a raycast from the check position to the playerAtual hits something...
		if(Physics.Raycast(checkPos, playerAtual.position - checkPos, out hit, relCameraPosMag))
		{
			// ... if it is not the playerAtual...
			if(hit.transform != playerAtual && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				// This position isn't appropriate.
				return false;
			}
		}
		// If we haven't hit anything or we've hit the playerAtual, this is an appropriate position.
		return true;
	}

	bool ReverseViewingPosCheck(Vector3 checkPos)
	{
		RaycastHit hit;

		if(Physics.Raycast(playerAtual.position, checkPos - playerAtual.position, out hit, relCameraPosMag))
		{
			if(hit.transform != transform && !hit.transform.GetComponent<Collider>().isTrigger)
			{
				return false;
			}
		}
		return true;
	}

	// Crosshair
	void OnGUI () 
	{
		float mag = Mathf.Abs ((aimPivotOffset - smoothPivotOffset).magnitude);
		if (PlayerBasic.IsAiming() &&  mag < 0.05f )
			GUI.DrawTexture(new Rect(Screen.width/2-(crosshair.width*0.5f), 
			                         Screen.height/2-(crosshair.height*0.5f), 
			                         crosshair.width, crosshair.height), crosshair);

	
	}
}
