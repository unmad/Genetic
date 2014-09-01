using UnityEngine;
using System.Collections;


public class BulletController : MonoBehaviour {

	public int dmg;
	public float speed;

	float timer;
	float lifetime;
	float startTime;

	void Start () {
		lifetime = 2f;
		startTime = Time.time;
	}

	void Update () {
		timer = Time.time;
		float spd = Mathf.Lerp(0f, speed, ((lifetime + startTime) - timer) / lifetime);
		transform.Translate(new Vector3 (0, 0, spd));
		if (spd < 0.1f)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider col){
		if(col.tag != "Bullet" && col.tag != "Eye"){
			if(col.tag == "Creature" || col.tag == "Player"){
				col.transform.SendMessage("SetDemage", dmg);
			}

			Destroy(this.gameObject);
		}
	}
}
