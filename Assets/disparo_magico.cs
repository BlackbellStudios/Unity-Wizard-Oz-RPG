using UnityEngine;
using System.Collections;

public class disparo_magico : MonoBehaviour {
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
		if (Colider.gameObject.name == "Monkey_Machadodeassis") {
			hud.GetComponent<HUD>().HP_MM -=10f;
		}
		if (Colider.gameObject.name == "Monkey_swors") {
			hud.GetComponent<HUD>().HP_ME -=10f;
		}
		if (Colider.gameObject.name == "macaco_atirador") {
			hud.GetComponent<HUD>().HP_MA -=10f;
		}
	
	}
}
