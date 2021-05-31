using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	[Header ("TEXTURAS")]
	public Texture Barra_Vida;
	public Texture Barra_Dorothy_Moldura;  	//Desenha as bordas e o Rosto do personagem
	public Texture Barra_Dorothy_Fundo;		//Desenha a imagem que fica atras da barra de vida
	public Texture Barra_Espantalho_Moldura;
	public Texture Barra_Espantalho_Fundo;
	public Texture Barra_HMDL_Moldura;
	public Texture Barra_HMDL_Fundo;

	[Header ("POSIÇOES")]
	public float PosX_Dorothy;				//Define a posiçao da HUD no eixo X
	public float PosY_Dorothy;				//Define a posiçao da HUD no eixo Y
	public float PosX_Espantalho;
	public float PosY_Espantalho;
	public float PosX_HMDL;
	public float PosY_HMDL;

	[Header ("DIMENSOES")]
	public float LargVida_Dorothy;
	public float LargVida_Espantalho;
	public float LargVida_HMDL;

	[Header ("HP MAX/ATUAL")]
	public float HP_Max;				
	public float HP_Dorothy;
	public float HP_Espantalho;
	public float HP_HMDL;

	public float HP_MM;
	public float HP_ME;
	public float HP_MA;
	public bool MM_Live;
	public bool ME_Live;
	public bool MA_Live;
	//public float HP_MM;

	public float Alt;
	public float Larg;

	[Header ("ESPANTALHO")]
	public GameObject Espantalho;   				//GameObject para receber o objeto
	public bool MorteEspantalho = false;			// Bool para ativar morte 
	private Animator AnimEspantalho;				//Carregar o animator do objeto
	private bool MorreuBool_Espantalho = false;		//Bool para caregar morte no animator

	[Header ("DOROTHY")]
	public GameObject Dorothy;
	public bool MorteDorothy = false;
	private Animator AnimDorothy;
	private bool MorreuBool_Dorothy = false;

	[Header ("HMDL")]
	public GameObject HMDL;
	public bool MorteHMDL = false;
	private Animator AnimHMDL;
	private bool MorreuBool_HMDL = false;


	// Use this for initialization
	void Start () {
		// Posiçao HUD - DOROTHY na tela
		PosX_Dorothy = Screen.width / 2 - Screen.width / 2;
		PosY_Dorothy = Screen.height / 2 - Screen.height / 2f;

		// Posiçao HUD - ESPANTALHO na tela
		PosX_Espantalho = Screen.width / 2 - Screen.width / 2;
		PosY_Espantalho = Screen.height / 2 - Screen.height / 3.8f;

		// Posiçao HUD - HOMEM DE LATA na tela
		PosX_HMDL = Screen.width / 2 - Screen.width / 2;
		PosY_HMDL = Screen.height / 2 - Screen.height / 18f;

		//Vida Total
		HP_Max = 100;
		HP_Dorothy = 100;
		HP_Espantalho = 100;
		HP_HMDL = 100;

		//vida inimigo
		HP_ME = 100;
		HP_MM = 100;
		HP_MA = 100;
		MA_Live = false;
		ME_Live = false;
		MM_Live = false;
		MortesControle ();

		Espantalho = GameObject.Find ("Espantalho");			//Acha o objeto espantalho no inspetor, e o carrega em um gameobject 
		AnimEspantalho = Espantalho.GetComponent<Animator> ();	//puxa o componente animation dentro do objeto carregado

		Dorothy = GameObject.Find ("Dorothy_Player");
		AnimDorothy = Dorothy.GetComponent<Animator> ();

		HMDL = GameObject.Find ("HMDL");
		AnimHMDL = HMDL.GetComponent<Animator> ();
		//MorreuBool = Animator.StringToHash("Morreu");

	}
	
	// Update is called once per frame
	void Update () {

		//Impede que a Vida dos inimigos fiquem negativas 

		if (HP_Dorothy <= 0) {
						HP_Dorothy = 0;			//Impede que o HP seja negativo.
						MorteDorothy = true;	//Ativa o if que toca a animaçao de morte da personagem
						MortesControle ();		//executa o Void onde o if esta alocado e possibilita a morte do personagem
				}
		if (HP_Espantalho <= 0){
						HP_Espantalho = 0;
						MorteEspantalho = true;
						MortesControle();
			}

		if (HP_HMDL <= 0) {
						HP_HMDL = 0; 
						MorteHMDL = true;
						MortesControle();
				}
		if (HP_ME <= 0) {
			//Destroy(macaco_espada);
			ME_Live = true;
		}
		if (HP_MM <= 0) {
			//Destroy(Macaco_Machado);
			MM_Live = true;
		}
		if (HP_MA <= 0) {
			//Destroy(Macaco_Machado);
			MA_Live = true;
		}

		if (HP_ME >= 100) {
			HP_ME =100;
		}
		if (HP_MM >= 100) {
			HP_MM = 100;
		}

		if (HP_Dorothy >= 100)
						HP_Dorothy = 100;
		
		if (HP_Espantalho >= 100)
						HP_Espantalho = 100;
		
		if (HP_HMDL >= 100)
						HP_HMDL = 100; 
	}
	void MortesControle(){

		if (MorteEspantalho) {
			MorreuBool_Espantalho = true;
			//Espantalho.gameObject.GetComponent<PlayerBasicMovement>().enabled = false;
			//Espantalho.gameObject.GetComponent<PlayerBasicFollow>().enabled = false;
			AnimEspantalho.SetBool ("Morreu", MorreuBool_Espantalho);
		}
		if (MorteDorothy) {
			MorreuBool_Dorothy = true;
			//Dorothy.gameObject.GetComponent<PlayerBasicMovement>().enabled = false;
			//orothy.gameObject.GetComponent<PlayerBasicFollow>().enabled = false;
			AnimDorothy.SetBool ("Morreu", MorreuBool_Dorothy);
		}
		if (MorteHMDL) {
			MorreuBool_HMDL = true;
			//Dorothy.gameObject.GetComponent<PlayerBasicMovement>().enabled = false;
			//orothy.gameObject.GetComponent<PlayerBasicFollow>().enabled = false;
			AnimHMDL.SetBool ("Morreu", MorreuBool_HMDL);
		}

	}

	void OnGUI(){

		// Dimensoes padroes HUD
		Alt = Screen.height / 2 - Screen.height / 4;
		Larg = Screen.width / 2 - Screen.width / 4;

		//VALOR BARRA VIDA
		LargVida_Dorothy = (Screen.width / 4)*(HP_Dorothy/HP_Max);
		LargVida_Espantalho = (Screen.width / 4)*(HP_Espantalho/HP_Max);
		LargVida_HMDL = (Screen.width / 4)*(HP_HMDL/HP_Max);

		//HUD - DOROTHY
		GUI.DrawTexture (new Rect(PosX_Dorothy, PosY_Dorothy, Larg,Alt),Barra_Dorothy_Fundo);
		GUI.DrawTexture (new Rect(PosX_Dorothy + ((Screen.width / 4)*(1-(HP_Dorothy/HP_Max)) /2.6f), PosY_Dorothy, LargVida_Dorothy, Alt),Barra_Vida);
		GUI.DrawTexture (new Rect(PosX_Dorothy, PosY_Dorothy, Larg,Alt),Barra_Dorothy_Moldura);

		//HUD - ESPANTALHO
		GUI.DrawTexture (new Rect(PosX_Espantalho, PosY_Espantalho, Larg,Alt),Barra_Espantalho_Fundo);
		GUI.DrawTexture (new Rect(PosX_Espantalho + ((Screen.width / 4)*(1-(HP_Espantalho/HP_Max)) /2.6f), PosY_Espantalho, LargVida_Espantalho, Alt),Barra_Vida);
		GUI.DrawTexture (new Rect(PosX_Espantalho, PosY_Espantalho, Larg,Alt),Barra_Espantalho_Moldura);

		//HUD - HOMEM DE LATA
		GUI.DrawTexture (new Rect(PosX_HMDL, PosY_HMDL, Larg,Alt),Barra_HMDL_Fundo);
		GUI.DrawTexture (new Rect(PosX_HMDL + ((Screen.width / 4)*(1-(HP_HMDL/HP_Max)) /2.6f), PosY_HMDL, LargVida_HMDL, Alt),Barra_Vida);
		GUI.DrawTexture (new Rect(PosX_HMDL, PosY_HMDL, Larg,Alt),Barra_HMDL_Moldura);
	}
}
