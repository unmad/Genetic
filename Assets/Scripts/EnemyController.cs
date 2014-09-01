using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {
	
	public float attackRange;
	public float moveRangeToStop;
	
	Transform target;

	Logic logic;

	float mapWidth;
	float mapHeight;

	//States
	bool attackState;
	//States end
	
	
	//Magic
	string wayTag = "Waypoint";
	//Magic End
	
	public GameObject bullet;
	public GameObject gun;
	public float attackSpeed = 0.5f;
	public int dmg;
	public float accuracy;
	
	private bool attacking;
	private bool attack;
	
	float lastAttack;
	
	void Start () {
		logic = Logic.Instance;
		mapHeight = logic.mapHeight - logic.borderSize;
		mapWidth = logic.mapWidth - logic.borderSize;
		attacking = false;
		attackState = false;
		lastAttack = Time.time;
	}
	
	void Update () {
		//Debug.Log("update");
		if (target == null){
			Run ();
		}else {
			SendMessage("MoveTo", target.position);
		}
		if (lastAttack + attackSpeed < Time.time && attacking){
			attacking = false;
		}
		
		if (!attacking && attack){
			//Debug.Log("attack");
			var newRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
			transform.rotation = newRotation;
			lastAttack = Time.time;
			attack = false;
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

	public void InPosition(){
		//Debug.Log("inpos");
		if (attackState){
			attack = true;
		}else Run();
	}
	
	
	void DestroyWaypoint(){
		//Debug.Log("destroyway");
		if (target != null && target.tag == wayTag)
			Destroy (target.gameObject);
	}
	
	void Run(){
		Vector2 point;
		point = new Vector2(0f, 0f);

		point = transform.position.ToVector2() + Random.insideUnitCircle * 5f;
		
		point.x = Mathf.Clamp(point.x, -mapWidth/2, mapWidth/2);
		point.y = Mathf.Clamp(point.y, -mapHeight/2, mapHeight/2);
		NewWayPoint (point);
		SendMessage("SetRangeToStop", moveRangeToStop);
		SendMessage("MoveTo", target.position);
	}
	
	void NewWayPoint(Vector2 point){
		//Debug.Log("newway");
		DestroyWaypoint();
		
		var wayPoint = new GameObject();
		target = wayPoint.transform;
		target.gameObject.name = wayTag;
		target.gameObject.tag = wayTag;
		target.position = new Vector3(point.x, 1f, point.y);
	}
	
	void SeePlayer (Transform t){
		//Debug.Log("seeplayer");
		attackState = true;

		if (target.tag == wayTag)
			DestroyWaypoint();

		SendMessage("SetRangeToStop", attackRange);
		target = t;
	}
	
	void EscPlayer (Transform t){
		//Debug.Log("escplayer");
		attackState = false;
		Run ();
	}
	void Die(){
		Destroy(this.gameObject);
	}
}
