using UnityEngine;
using System.Collections;

public class PlayerControlEspantalho : MonoBehaviour
{
	public static PlayerControlEspantalho CurrentPlayer;
	public static int PlayerON;
	
	public Transform Player;
	public GameObject PlayerAtualCamera;
	public Vector3 dist;
	public float distancia;
	public int SegVel;

	

	void Awake()
	{
		CurrentPlayer = this;
		PlayerON = 2;
	}
	
	void Update()
	{
		if (PlayerON == 1) {
			Debug.Log ("ESPANTALHO E O PLAYER ATUAL");
			this.gameObject.GetComponent<PlayerBasicMovement>().enabled = true;
			this.gameObject.GetComponent<PlayerBasicFollow>().enabled = false;
		} 
		if (PlayerON == 2) {
			this.gameObject.GetComponent<PlayerBasicMovement>().enabled = false;
			this.gameObject.GetComponent<PlayerBasicFollow>().enabled = true;
		} 
		if (PlayerON == 3) {
			Debug.Log ("ESPANTALHO AGUARDA");
			this.gameObject.GetComponent<PlayerBasicMovement>().enabled = false;
			this.gameObject.GetComponent<PlayerBasicFollow>().enabled = false;
		} 
	}

		
}

