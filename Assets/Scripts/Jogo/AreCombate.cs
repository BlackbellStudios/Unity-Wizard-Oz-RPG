using UnityEngine;
using System.Collections;

public class AreCombate : MonoBehaviour {

	public GameObject[] Walls;
	public GameObject[] Particulas;
	public int Fumaca;
	
	void Start () {
	
		for(int i = 0; i < Particulas.Length; i++)
	{
		Particulas[i].SetActive(false);
	}

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider Colider){
		if (Colider.gameObject.tag == "Player") {

			for(int i = 0; i < Walls.Length; i++)
			{
				Walls[i].gameObject.GetComponent<Collider>().isTrigger = false;
			}

//			Walls[0].gameObject.collider.isTrigger = false;
//			Walls[1].gameObject.collider.isTrigger = false;
//			Walls[2].gameObject.collider.isTrigger = false;
//			Walls[3].gameObject.collider.isTrigger = false;
//			Walls[4].gameObject.collider.isTrigger = false;
			Destroy (this);

			for(int i = 0; i < Particulas.Length; i++)
			{
				Particulas[i].SetActive(true);
			}
		}
	}
}
