using UnityEngine;
using System.Collections;

public class macaco_arma : MonoBehaviour {
	public GameObject Player;
	public GameObject Player2;
	//public GameObject Player3;
	public GameObject tiro;
	public float vida1;
	public float vida2;

	public float tempo;
	public float tempo2;
	public float tempo3;
	public float tempo4;
	//public float vida3;
	// Use this for initialization
	void Start () {
		tempo = 0;
		tempo2 = 0;
		tempo3 = 0;
		tempo4 = 0;
		Player2 = GameObject.Find("Espantalho").gameObject;
		Player = GameObject.Find("Dorothy").gameObject;
		tiro = GameObject.Find ("tiro").gameObject;
		//Player3 = GameObject.Find ("Homem_de_lata").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		timers ();
		disparo ();

		//vida2 = Player2.GetComponent<PlayerControlEspantalho> ().vida_espantalho;
		//vida1 = Player.GetComponent<PlayerControl> ().vida_player;
		//vida3 = Player3.GetComponent<PlayerControlHomemDeLata> ().vida_HM;

		//PlayerControlEspantalho.vida_espantalho
			if(vida1 > 0){
				Debug.Log("FUNCIONO!!!!" + vida1);
				//Player = GameObject.Find("Espantalho");
				if(tempo>0.5f){
				transform.LookAt(Player.transform.position);
				//transform.LookAt(Pla
					tempo=0.2f;
				}
				}
			else if(vida2 > 0 && vida1 <=0){
				Debug.Log("FUNCIONO v3!!!!"+ vida2);
				//Player = GameObject.Find("Espantalho");
				transform.LookAt(Player2.transform.position);
				//transform.LookAt(Pla
			}
			/*if(vida3 > 0){
			Debug.Log("FUNCIONO!!!!" + vida3);
			//Player = GameObject.Find("Espantalho");
			transform.LookAt(Player3.transform.position);
			//transform.LookAt(Pla
		}*/
	}
	void timers(){
		tempo += Time.deltaTime;
		tempo2 += Time.deltaTime;
		tempo3 += Time.deltaTime;
		tempo4 += Time.deltaTime;

	}
	void disparo(){

		if(tempo2>1.3f){
			if(tempo3>0.2f){		
			Instantiate (tiro, new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z + 1), Quaternion.identity);
				tempo3=0;
			}

					}
		if (tempo4 >= 1.5f && tempo2 > 0.7f) {
			tempo4=-2;
			tempo2=-2f;

		}


	}
}
