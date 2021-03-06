using UnityEngine;
using System.Collections;

public class macaco_tiro : MonoBehaviour {

	[Header("GAMEOBJECTS")]
	public GameObject EspantalhoPlay;
	public GameObject DorothyPlay;
	public GameObject HomemDeLata;
	public GameObject disparo;
	public GameObject HUD;
	
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
	
	[Header("TIMERS")]
	public float tempo_olha;
	public float tempo_action;
	public float tempo_prepara_ataque;
	public float tempo_reset;
	public float tempo_percurso;
	public float tempo2;
	public float tempo3;
	public float tempo4;
	public float tempo_restart;//tempo para voltar valor de locomoçao de ataque
	
	public int sorteio;
	public float position;
	public float ataque;
	public bool para_andar;
	public Animator animator;
	public GameObject tiro;
	public float limite;
	// Use this for initialization
	void Start () {
		
		//vida = 100;
		//tempo_restart = 3;
		
		animator = this.gameObject.GetComponent<Animator> ();
		//ataque = 4;
		
		EspantalhoPlay = GameObject.Find("Espantalho").gameObject;
		DorothyPlay = GameObject.Find("Dorothy_Player").gameObject;
		HomemDeLata = GameObject.Find ("HMDL").gameObject;
		HUD = GameObject.Find ("Main Camera Game").gameObject;
		tiro = GameObject.Find ("tiro-inimigo").gameObject;


		Espantalho_Pos = GameObject.Find("Espantalho").transform;
		Dorothy_Pos = GameObject.Find("Dorothy_Player").transform;
		HMDL_Pos = GameObject.Find("HMDL").transform;
		
		
		tempo_olha = 0;
		tempo_action = 0;
		tempo_prepara_ataque = 0;
		tempo_reset = 0;
		tempo_restart = 3;
		tempo_percurso = 0;
		tempo2 = 0;
		tempo3 = 0;
		tempo4 = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
		movimento ();
		times ();
		vidax ();

		limite = transform.position.y;
		vida = HUD.GetComponent<HUD> ().MM_Live;
		
		vida_espantalho = HUD.GetComponent<HUD> ().HP_Espantalho;
		vida_dorothy = HUD.GetComponent<HUD> ().HP_Dorothy;
		vida_homemDeLata = HUD.GetComponent<HUD> ().HP_HMDL;
		
		//selecao
		if (vida_dorothy > 0) {
			playerFoco = Dorothy_Pos;

		} 
		
		else if (vida_dorothy <= 0 && vida_homemDeLata > 0) {
			playerFoco = HMDL_Pos;
		}
		
		else if(vida_espantalho > 0 && vida_homemDeLata <=0 && vida_dorothy <=0){
			playerFoco = Espantalho_Pos;
		}
		
		limite = 45f;
		
		/*if (tempo_restart >= 3) {
			
			ataque = 8;
		}*/
		
		//ataque
		if (playerFoco == Espantalho_Pos) {
			if (tempo_olha > 0.5f) {
				transform.LookAt (Espantalho_Pos.transform.position);
				tempo_olha = 0.2f;
			}
			
		}
		
		
		if(playerFoco == Dorothy_Pos) {
			
			if (tempo_olha > 0.5f) {
				transform.LookAt (Dorothy_Pos.transform.position);
				tempo_olha = 0.2f;
			}
			


		}
		if(playerFoco == HMDL_Pos) {
			
			if (tempo_olha > 0.5f) {
				transform.LookAt (HMDL_Pos.transform.position);
				tempo_olha = 0.2f;
			}

		}
		
		if (tempo_reset >= 1.5f && tempo_action > 0.7f) {
			tempo_reset=-2;
		}




		if(tempo2>1.3f){
			animator.SetBool("atirar",true);
			if(tempo3>0.5f){
				
				//animator.SetBool("disparo",true);
				
				
				//Instantiate (tiro,GameObject.Find("mira_esquerda").transform.position,GameObject.Find("mira_esquerda").transform.rotation);
				
				//Instantiate (tiro, GameObject.Find("mira_direita").transform.position, GameObject.Find("mira_direita").transform.rotation );
				
				tempo3=0;
				
				
				
			}
			
		}
		if (tempo4 >= 1.5f && tempo2 > 0.7f) {
			tempo4=-2;
			tempo2=-0f;
			
			animator.SetBool("atirar",false);
			
		}
		

	}
	
	void movimento(){
		
		if (tempo_percurso >= 4) {
			sorteio = Random.Range (0, 7);
			tempo_percurso = 0;
		}
		
		switch (sorteio) {
		case 1:
			transform.Translate (2 * Time.deltaTime, 0, 0);
			break;
			
		case 2:
			transform.Translate (-2 * Time.deltaTime, 0, 0);
			break;
			
		case 3:
			transform.Translate (2 * Time.deltaTime, 0, -1*Time.deltaTime);
			break;
			
		case 4:
			transform.Translate (-2 * Time.deltaTime, 0, 2*Time.deltaTime);
			break;
			
		case 5:
			Debug.Log("ataque");
			transform.Translate (0,0,-4 * Time.deltaTime);
			break;
			
		case 6:
			transform.Translate (0,0,-4 * Time.deltaTime);//tempo_movimento = 1;		
			break;
		}
	}
	
	void vidax(){
		
		if (vida) {
			Destroy(gameObject);
		} 
	}
	
	void times(){
		tempo_olha += Time.deltaTime;
		tempo_action += Time.deltaTime;
		tempo_reset += Time.deltaTime;
		tempo_percurso += Time.deltaTime;
		tempo_restart += Time.deltaTime;
		tempo2 += Time.deltaTime;
		tempo3 += Time.deltaTime;
		tempo4 += Time.deltaTime;

	}
}
