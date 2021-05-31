
using UnityEngine;
using System.Collections;

public class FuracaoRotate : MonoBehaviour {
	public float FORCE = 30;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, FORCE * Time.deltaTime);
	}
}
