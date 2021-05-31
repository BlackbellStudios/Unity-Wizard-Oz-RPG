using UnityEngine;
using System.Collections;

public class MissoesAI : MonoBehaviour {
	public Vector3 newposition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKey (KeyCode.M)){
		   this.transform.position  = GameObject.Find("Missao1").transform.position;
		   
	}
	}
}
