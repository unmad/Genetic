using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	public GameObject bullet;
	public GameObject gun;
	public float attackSpeed = 0.5f;
	public int dmg;
	public float accuracy;

	private bool attacking;
	
	float lastAttack;
	
	void Start () {
		attacking = false;
		lastAttack = Time.time;
	}

	void Update () {

		if (lastAttack + attackSpeed < Time.time && attacking){
			attacking = false;
		}

		if (!attacking && Input.GetButtonDown("Fire1")){
			lastAttack = Time.time;
			attacking = true;
			GameObject bul = Instantiate(bullet) as GameObject;

			BulletController bc = bul.GetComponent<BulletController>();
			bc.dmg = dmg;
			bc.speed = 0.3f;

			bul.transform.position = gun.transform.position;
			bul.transform.rotation = gun.transform.rotation;
			bul.transform.Rotate(0f,Random.Range(-accuracy,accuracy), 0f);
		}
	}
}
