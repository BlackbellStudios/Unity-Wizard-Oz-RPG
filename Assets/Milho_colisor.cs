using UnityEngine;
using System.Collections;

public class Milho_colisor : MonoBehaviour {
	public GameObject Milho;
	public bool TimeAtivo;
	public float TimeTempo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeAtivo) 
			TimeTempo += Time.deltaTime;		

		if (TimeTempo > 2) {
			Milho.gameObject.GetComponent<Milho>().enabled = false;
			Destroy(gameObject);
		}

	}
	void OnCollisionEnter(Collision Colider){


		if (Colider.gameObject.tag == "Player") {
			TimeAtivo = true;

		}
		}
}
