using UnityEngine;
using System.Collections;

public class Milho : MonoBehaviour {
	public Transform MilhoInclinacao;

	// Use this for initialization
	void Start () {
		//transform.Rotate (new Vector3 (44.51097f, 348.8904f, 19.75085f));
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (MilhoInclinacao.transform.position);
		transform.Rotate (new Vector3 (134f, -12f, 0));
	}
}
