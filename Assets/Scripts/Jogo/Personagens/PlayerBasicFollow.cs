using UnityEngine;
using System.Collections;

public class PlayerBasicFollow : MonoBehaviour {
	public Vector3 dist;
	public float distancia;
	public float SegVel = 0;
	public GameObject Player;

	public float walkSpeed = 0.15f;
	public float runSpeed = 1.0f;
	public float speedDampTime = 0.1f;
	private float speed;

	private Animator anim;
	private int speedFloat;
	private int groundedBool;
	private int RotateAngle;

	// Use this for initialization
	void Start () {
		RotateAngle = 180;
		anim = GetComponent<Animator> ();
		speedFloat = Animator.StringToHash("Speed");
		groundedBool = Animator.StringToHash("Grounded");
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.Find("Main Camera Game").GetComponent<ThirdPersonOrbitCam>().playerAtual.gameObject;

		dist = transform.position -	Player.transform.position;
		distancia = Mathf.Sqrt(dist.x*dist.x+dist.z*dist.z);

		if (this.name == "Espantalho") {
			Vector3 distFollow;
			GameObject PlayerlHMDL =  GameObject.Find ("HMDL").gameObject;
			distFollow = transform.position -	PlayerlHMDL.transform.position;
			float distanciaFollow = Mathf.Sqrt(distFollow.x*distFollow.x+distFollow.z*distFollow.z);
			if(distanciaFollow < 3){
				transform.LookAt (PlayerlHMDL.transform.position);
				transform.Rotate(new Vector3 (0,180,0));
				transform.Translate (new Vector3(0,0, SegVel)*Time.deltaTime);
			}
		}
		//string DEFNAME = "DEF" + this.name.ToString();
		if (this.name == "HMDL") {
			Vector3 DFEspantalho;
			GameObject PlayerlEspantalho =  GameObject.Find ("Espantalho").gameObject;
			DFEspantalho = transform.position -	PlayerlEspantalho.transform.position;
			float DistanceCalc = Mathf.Sqrt(DFEspantalho.x*DFEspantalho.x+DFEspantalho.z*DFEspantalho.z);
			if(DistanceCalc < 3){
				transform.LookAt (PlayerlEspantalho.transform.position);
				transform.Rotate(new Vector3 (0,180,0));
				transform.Translate (new Vector3(0,0, SegVel)*Time.deltaTime);
			}
		}


		if (distancia > 10) {
			RotateAngle=180;
			speed = runSpeed;
			SegVel = 6;
			transform.LookAt (Player.transform.position);
			transform.Translate (0, 0, SegVel*Time.deltaTime);
		}
		if (distancia >= 5){
			RotateAngle=0;
			speed = walkSpeed;
			SegVel = 3;
			transform.LookAt (Player.transform.position);
			transform.Translate (0, 0, SegVel*Time.deltaTime);	
		}
		if (distancia < 5 ){
			transform.LookAt (Player.transform.position);
			RotateAngle=0;
			SegVel = 0;
			speed = SegVel;
		}
		anim.SetFloat(speedFloat, speed, speedDampTime, Time.deltaTime);
	
	}
}
