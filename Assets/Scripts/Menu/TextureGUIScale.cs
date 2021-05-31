
using UnityEngine;
using System.Collections;

public class TextureGUIScale : MonoBehaviour {
	public GUITexture Menu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MenuScale ();
	}
	void MenuScale(){
	
		float Alt = Screen.width;
		float Lag = Screen.height;
		float PosX= Screen.width/2f - Screen.width;
		float PosY = Screen.height/1.95f - Screen.height;

		Menu.pixelInset =(new Rect(PosX, PosY, Alt, Lag));
	}

}
