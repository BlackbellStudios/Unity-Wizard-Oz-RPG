using UnityEngine;
using System.Collections;

public class localizador : MonoBehaviour {
	public Vector3 newposition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		newposition = GameObject.Find("ProxMissao").transform.position;
		newposition.x += 1f;
		newposition.z += 1f;
		if( newposition.x >= GameObject.Find("ProxMissao").transform.position.x + 1 ||  newposition.z >= GameObject.Find("ProxMissao").transform.position.z + 1)
		{
			transform.LookAt(newposition);
			transform.Rotate(0,5 * Time.deltaTime,0 );
		}

	}
}
