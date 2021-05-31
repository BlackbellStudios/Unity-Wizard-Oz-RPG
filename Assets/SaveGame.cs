using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour {

	private Vector3 DorothyPos;
	private Quaternion DorothyRot;

	private Vector3 EspantalhoPos;
	private Quaternion EspantalhoRot;

	private bool PressSave;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		PressSave = Input.GetButtonDown ("ComandoGeral");

		float distance = Vector3.Distance (GameObject.Find ("Main Camera Game").GetComponent<ThirdPersonOrbitCam> ().playerAtual.transform.position, transform.position);

		if (distance < 10) {
			Debug.Log("AreaSave");
			if (PressSave){
				Debug.Log ("Salvando......");
				Save ();

			}
		}

	}
	void Save(){
		BinaryFormatter BF = new BinaryFormatter ();
		FileStream file;
		PlayData data = new PlayData ();



		DorothyPos = GameObject.Find ("Dorothy").transform.position;
		DorothyRot = GameObject.Find ("Dorothy").transform.rotation;

		EspantalhoPos = GameObject.Find ("Espantalho").transform.position;
		EspantalhoRot = GameObject.Find ("Espantalho").transform.rotation;

		file = File.Create(Application.persistentDataPath + "/PlayersSave.dat");
		data.SavePlayerAtual = GameObject.Find ("Main Camera Game").GetComponent<ThirdPersonOrbitCam> ().DefinePlayer;

		data.DorothyPosX = DorothyPos.x;
		data.DorothyPosY = DorothyPos.y;
		data.DorothyPosZ = DorothyPos.z;

		data.DorothyRotX = DorothyRot.x;
		data.DorothyRotY = DorothyRot.y;
		data.DorothyRotZ = DorothyRot.z;

		data.EspantalhoPosX = EspantalhoPos.x;
		data.EspantalhoPosY = EspantalhoPos.y;
		data.EspantalhoPosZ = EspantalhoPos.z;
		
		data.EspantalhoRotX = EspantalhoRot.x;
		data.EspantalhoRotY = EspantalhoRot.y;
		data.EspantalhoRotZ = EspantalhoRot.z;


		BF.Serialize (file, data);
		file.Close ();
	}
	public void Load (){
		if (File.Exists (Application.persistentDataPath + "/PlayersSave.dat")) {
		
			BinaryFormatter BF = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/PlayersSave.dat", FileMode.Open);
			PlayData data = (PlayData)BF.Deserialize(file);
			file.Close ();

			GameObject.Find ("Main Camera Game").GetComponent<ThirdPersonOrbitCam> ().DefinePlayer = data.SavePlayerAtual;

			DorothyPos.x = data.DorothyPosX;
			DorothyPos.y = data.DorothyPosY;
			DorothyPos.z = data.DorothyPosZ;
			
			DorothyRot.x = data.DorothyRotX;
			DorothyRot.y = data.DorothyRotY;
			DorothyRot.z = data.DorothyRotZ;
			
			EspantalhoPos.x = data.EspantalhoPosX;
			EspantalhoPos.y = data.EspantalhoPosY;
			EspantalhoPos.z = data.EspantalhoPosZ;
			
			EspantalhoRot.x = data.EspantalhoRotX;
			EspantalhoRot.y = data.EspantalhoRotY;
			EspantalhoRot.z = data.EspantalhoRotZ;

			GameObject.Find ("Dorothy").transform.position = DorothyPos;
			GameObject.Find ("Dorothy").transform.rotation = DorothyRot;

			GameObject.Find ("Espantalho").transform.position = EspantalhoPos;
			GameObject.Find ("Espantalho").transform.rotation = EspantalhoRot;
		}
	}

}

[System.Serializable]
class PlayData
{
	public float DorothyPosX;
	public float DorothyPosY;
	public float DorothyPosZ;

	public float EspantalhoPosX;
	public float EspantalhoPosY;
	public float EspantalhoPosZ;

	public float DorothyRotX;
	public float DorothyRotY;
	public float DorothyRotZ;
	
	public float EspantalhoRotX;
	public float EspantalhoRotY;
	public float EspantalhoRotZ;

	public int SavePlayerAtual;
}
