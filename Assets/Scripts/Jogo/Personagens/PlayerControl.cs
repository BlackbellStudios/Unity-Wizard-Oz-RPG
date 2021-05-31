using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public static PlayerControl CurrentPlayer;
	public static int PlayerON;

	public Transform Player;
	public GameObject PlayerAtualCamera;

	public Vector3 dist;
	public float distancia;
	public int SegVel;

	public GameObject disparo_magico;

	
	void Awake()
	{
		CurrentPlayer = this;
		PlayerON = 1;
	}

	void Update()
	{
		if (PlayerON == 1) {
			Debug.Log ("DOROTHY E O PLAYER ATUAL");

			this.gameObject.GetComponent<PlayerBasicMovement>().enabled = true;
			this.gameObject.GetComponent<PlayerBasicFollow>().enabled = false;
			//this.gameObject.GetComponent<mira_dorothy>().dot = true;

		} 
		if (PlayerON == 2) {
			this.gameObject.GetComponent<PlayerBasicMovement>().enabled = false;
			this.gameObject.GetComponent<PlayerBasicFollow>().enabled = true;
		} 
		if (PlayerON == 3) {
			Debug.Log ("DOROTHY AGUARDA");

		} 

	}
}
