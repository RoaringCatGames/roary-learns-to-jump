using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

	public float respawnTriggerY = -10f;
	public Vector2 respawnPosition = new Vector2(1f, 1f);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y <= respawnTriggerY){
			transform.position = respawnPosition;
		}
	}
}
