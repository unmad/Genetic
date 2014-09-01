using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;
	public float speedToRotate;
	public float rangeToStop;

	void MoveTo(Vector3 tar){
		//Debug.Log("moveto");
		if (!Utils.InRange (transform.position, tar, rangeToStop)) {
			var newRotation = Quaternion.LookRotation(tar - transform.position, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, (float)speed * speedToRotate);
			transform.Translate (Vector3.forward * speed);
			Debug.DrawLine (transform.position, tar);
		} else SendMessage("InPosition");
	}

	void SetRangeToStop(float r){rangeToStop = r;}
}
