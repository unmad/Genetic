using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Eyesight : MonoBehaviour {

	public GameObject me;
	GameObject player;
	public float SightRange;

	bool seePlayer;

	void Start (){
		var pm = FindObjectOfType<PlayerMover>();
		player = pm.gameObject;
	}

	void Update(){
		if (Utils.InRange(transform.position, player.transform.position, SightRange)){
			me.SendMessage("SeePlayer", player.transform);
			seePlayer = true;
		}else if (seePlayer) {
			me.SendMessage("EscPlayer", player.transform);
			seePlayer = false;
		}
	}

//	void OnTriggerEnter (Collider col) {
//
//		if (col.gameObject.tag == "Player"){
//			//Debug.Log("SeePlayer");
//			me.SendMessage("SeePlayer", col.transform);
//		}
//	}
//
//	void OnTriggerExit (Collider col){
//
//		if (col.gameObject.tag == "Player"){
//			//Debug.Log("EscPlayer");
//			me.SendMessage("EscPlayer", col.transform);
//		}
//	}

}
