using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GameObject Alvo;
	public GameObject go;
//	public GameObject Som_Menu;

	public bool IJ;
	public bool CJ;
	public bool OJ;
	public bool verifica_som;

	public AudioClip Som_Botao;
	public AudioClip Som_Troca;
	public AudioClip Som_Fundo;

	public float con_Tempo;
	public bool ativa_tempo;

	public bool LoadTest;
	public float LoadTime;



	public string Som;
	// Use this for initialization
	void Start () {
		Alvo = GameObject.Find ("Waypoint").gameObject;
		Som= "Som: Ativado";
		verifica_som = true;

//		audio.Play ();

	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (ativa_tempo) {
			con_Tempo+= Time.deltaTime;
			
			if(con_Tempo >2.8f){
				Application.LoadLevel("Cena1");
			}
		}
		if (LoadTest){
			LoadTime += Time.deltaTime;
			
//			if(LoadTime>= 5f){
				
				GameObject GO = GameObject.FindGameObjectWithTag ("SaveGameTotem").gameObject;
				GO.GetComponent<SaveGame>().Load();
				Destroy(gameObject);
//			}
		}
	}
	void Update () {
		transform.LookAt (Alvo.transform.position);
		transform.Translate (0, 0, 100 * Time.deltaTime);


	}

	void OnCollisionEnter(Collision Colider){
		Debug.Log ("Aqui");
		Alvo = Colider.gameObject.GetComponent<WaypointScripts> ().Proximo;
	}

	void OnGUI() {

		float posX = Screen.width / 2 - Screen.width / 2.5f;
		float posY = Screen.height - Screen.height /3.3f;
		float Alt = Screen.height / 20;
		float PosYIniciarJ = Screen.height - Screen.height /3.9f;
		float PosYIniciarCJ = Screen.height - Screen.height /4.8f;
		float Lag = Screen.width / 5;

		float PosXOpocao =Screen.width / 2 - Screen.width / 4.99f;

		float PosXSair =Screen.width / 2 - Screen.width /500f;



		// Botao iniciar
		if (GUI.Button (new Rect (posX, posY, Lag, Alt), "Iniciar")) {
			IJ = !IJ;
			OJ = false;
			//go.audio.clip= Som_Botao;
			go.GetComponent<AudioSource>().Play();

		}
			 // opçoes de inicia
		if (IJ) {
			if (GUI.Button (new Rect (posX, PosYIniciarJ, Lag, Alt), "Iniciar Jogo")) {
					go.GetComponent<AudioSource>().Play ();
					ativa_tempo = true;
					this.GetComponent<AudioSource>().clip = Som_Troca;
					this.GetComponent<AudioSource>().Play ();

	
			}

			if (GUI.Button (new Rect (posX, PosYIniciarCJ, Lag, Alt), "Carrega Jogo")) {
				go.GetComponent<AudioSource>().Play ();
				Application.LoadLevel("Cena1");
				LoadTest = true;
				this.gameObject.GetComponent<TextureGUIScale>().enabled = false;
				DontDestroyOnLoad (this.gameObject);
			}



									
		}

		// botao opçoes
		if (GUI.Button (new Rect (PosXOpocao, posY, Lag, Alt), "Opção")){
			OJ = !OJ;
			IJ = false;

			go.GetComponent<AudioSource>().Play ();
			
		}

		// Opçoes do botao opçao

		if (OJ) {
			if (GUI.Button (new Rect (PosXOpocao, PosYIniciarJ, Lag, Alt), Som)) {
				go.GetComponent<AudioSource>().Play();
				if(verifica_som){
					Som = "Som: Desativado";
					verifica_som = false ;
					GetComponent<AudioSource>().Stop();


				}else	if(verifica_som == false){
					Som = "Som: Ativado ";
					verifica_som = true;
					GetComponent<AudioSource>().clip = Som_Fundo;
					GetComponent<AudioSource>().Play();
				}

			}


				}


		// Botao sair
		if (GUI.Button (new Rect (PosXSair, posY, Lag, Alt), "Sair")) {
			go.GetComponent<AudioSource>().Play ();
			Debug.Log("Sai");	
			Application.Quit ();

		}

	}
	void OnMouseEnter(){
		Debug.Log("Iniciar");
	}

}
