using UnityEngine;
using System.Collections;

public class espada : MonoBehaviour {

	[Header("GAMEOBJECTS")]
	public GameObject HUD;
	public GameObject macaco;
	
	[Header("HP_ATUAL")]
	public float vida_espantalho;
	public float vida_dorothy;
	public float vida_homemDeLata;
	
	// Use this for initialization
	void Start () {
		//vida_espantalho = 100;
		HUD = GameObject.Find ("Main Camera Game").gameObject;
		macaco = GameObject.Find ("Monkey_Machadodeassis").gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//vida_dorothy = HUD.GetComponent<HUD> ().HP_Dorothy;
		//vida_homemDeLata = HUD.GetComponent<HUD> ().HP_HMDL;
		
	}
	void OnTriggerEnter(Collider Colider){
		
		if (Colider.gameObject.name == "HMDL") {
			HUD.GetComponent<HUD> ().HP_HMDL -= 10f;
			macaco.GetComponent<macaco_espada>().ataque =0;
			macaco.GetComponent<macaco_espada>().tempo_restart=0;
		}
		else if (Colider.gameObject.name == "Dorothy_Player") {
			HUD.GetComponent<HUD> ().HP_Dorothy -= 10f;
			macaco.GetComponent<macaco_espada>().ataque =0;
			macaco.GetComponent<macaco_espada>().tempo_restart=0;
		}
		else if (Colider.gameObject.name == "Espantalho") {
			HUD.GetComponent<HUD> ().HP_Espantalho -= 10f;
			macaco.GetComponent<macaco_espada>().ataque =0;
			macaco.GetComponent<macaco_espada>().tempo_restart=0;
		}
	}
}
