using UnityEngine;
using System.Collections;

public class mira_dorothy : MonoBehaviour {

	public Transform lookingObj;
	public Transform look;

	public GameObject disparo_magico;
	public bool dot;
	//public bool fool;

	public float speed = 10f;

	Plane ground;
	// Use this for initialization
	void Start (){
		dot = false;
		//dot = GetComponent<ThirdPersonOrbitCam> ().DefinePlayer;
	}
	
	// Update is called once per frame
	void Update () {

//		ground = new Plane (Vector3.up, transform.position);
//
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		float dist = 0f;
//
//		if (ground.Raycast (ray, out dist)) {
//		
//			Vector3 clickpoint = new Vector3(ray.GetPoint(dist).x,transform.position.y,ray.GetPoint(dist).z);
//			Quaternion targetRotation = Quaternion.LookRotation(clickpoint - transform.position);
//			transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,speed*Time.deltaTime);
//		
//		}


		/*if(dot){
			if (Input.GetKeyDown (KeyCode.Mouse1)) {
			
				Instantiate (disparo_magico, new Vector3 (transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			
			}
		}*/
	}
}
