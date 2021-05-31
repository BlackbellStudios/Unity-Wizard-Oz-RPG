using UnityEngine;
using System.Collections;

public class resp_1 : MonoBehaviour {
	public GameObject respawn;
	public GameObject respawn2;
	public GameObject respawn3;
	// Use this for initialization
	void Start () {
		Instantiate (respawn, new Vector3 (771.2062f, 50.04487f, 1836.033f), Quaternion.identity);
		Instantiate (respawn2, new Vector3 (761.2062f, 50.04487f, 1836.033f), Quaternion.identity);
		Instantiate (respawn3, new Vector3 (775.2062f, 50.04487f, 1836.033f), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
