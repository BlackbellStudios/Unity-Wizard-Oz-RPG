using UnityEngine;
using System.Collections;

public class tiro_inimigo : MonoBehaviour {
	public float veloc;
	public float tempo;
	
	public GameObject hud;
	
	
	// Use this for initialization
	void Start () {
		veloc = 8;
		tempo = 0;
		hud = GameObject.Find ("Main Camera Game").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		tempo += Time.deltaTime;
		transform.Translate (0, 0, veloc * Time.deltaTime);
		
		if (tempo > 3) {
			
			Destroy(gameObject);
			
		}
	}
	void OnTriggerEnter(Collider Colider){
		if (Colider.gameObject.name == "Dorothy_Player") {
			hud.GetComponent<HUD>().HP_Dorothy -=10f;
		}
		if (Colider.gameObject.name == "Espantalho") {
			hud.GetComponent<HUD>().HP_Espantalho -=10f;
		}
		if (Colider.gameObject.name == "HMDL") {
			hud.GetComponent<HUD>().HP_HMDL -=10f;
		}
		
	}
}
