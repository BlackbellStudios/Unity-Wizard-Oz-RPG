using UnityEngine;
using System.Collections;

public class mira_direita : MonoBehaviour {
	[Header("GAMEOBJECTS")]
	public GameObject EspantalhoPlay;
	public GameObject DorothyPlay;
	public GameObject HomemDeLata;
	public GameObject disparo;
	public GameObject HUD;
	public GameObject tiro;
	
	[Header("HP_ATUAL")]
	public float vida_espantalho;
	public float vida_dorothy;
	public float vida_homemDeLata;
	public bool vida;	
	
	[Header("TRANSFORMS")]
	public Transform Espantalho_Pos;
	public Transform Dorothy_Pos;
	public Transform HMDL_Pos;
	public Transform playerFoco;

	[Header("TIMES")]
	public float tempo_prepara;
	public float tempo_atira;
	public float tempo_reseta;
	// Use this for initialization
	void Start () {
		EspantalhoPlay = GameObject.Find("Espantalho").gameObject;
		DorothyPlay = GameObject.Find("Dorothy_Player").gameObject;
		HomemDeLata = GameObject.Find ("HMDL").gameObject;
		HUD = GameObject.Find ("Main Camera Game").gameObject;
		tiro = GameObject.Find ("tiro-inimigo").gameObject;
		
		Espantalho_Pos = GameObject.Find("Espantalho").transform;
		Dorothy_Pos = GameObject.Find("Dorothy_Player").transform;
		HMDL_Pos = GameObject.Find("HMDL").transform;

		tempo_atira = 0;
		tempo_prepara = 0;
		tempo_reseta = 0;
	}
	
	// Update is called once per frame
	void Update () {
		tempo_prepara += Time.deltaTime;
		tempo_reseta += Time.deltaTime;
		tempo_atira += Time.deltaTime;

		vida_espantalho = HUD.GetComponent<HUD> ().HP_Espantalho;
		vida_dorothy = HUD.GetComponent<HUD> ().HP_Dorothy;
		vida_homemDeLata = HUD.GetComponent<HUD> ().HP_HMDL;

		/*if (vida_dorothy > 0) {
			playerFoco = Dorothy_Pos;
			
		} 
		
		else if (vida_dorothy <= 0 && vida_homemDeLata > 0) {
			playerFoco = HMDL_Pos;
		}
		
		else if(vida_espantalho > 0 && vida_homemDeLata <=0 && vida_dorothy <=0){
			playerFoco = Espantalho_Pos;
		}*/

		if(tempo_prepara>1.3f){
			//animator.SetBool("atirar",true);
			if(tempo_atira>0.5f){
				
				//animator.SetBool("disparo",true);
				
				
				Instantiate (tiro,new Vector3 (transform.position.x,transform.position.y,transform.position.z),transform.rotation);
				
				//Instantiate (tiro, GameObject.Find("mira_direita").transform.position, GameObject.Find("mira_direita").transform.rotation );
				
				tempo_atira=0;
				
				
				
			}
			
		}
		if (tempo_reseta >= 1.5f && tempo_prepara > 0.7f) {
			tempo_reseta=-2;
			tempo_prepara=-0f;
			
			//animator.SetBool("atirar",false);
			
		}


	}
}
