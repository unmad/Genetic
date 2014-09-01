using UnityEngine;
using System.Collections;

public class Logic : Singleton <Logic> {

	public GameObject enemy1Prefab;
	public GameObject enemy2Prefab;
	public GameObject wallPrefab;
	public GameObject floorPrefab;
	public int mapWidth;
	public int mapHeight;
	public float borderSize;
	public int countOfEnemy1;
	public int countOfEnemy2;
	GameObject player;

	void Start () {
		GenWalls();
		player = FindObjectOfType<PlayerMover>().gameObject;
		GenEnemy(countOfEnemy1,countOfEnemy2);
	}

	void Update () {
		Vector3 camPos = new Vector3 (0f, 0f, 0f);
		camPos = player.transform.position;
		camPos.y = Camera.main.transform.position.y;
		Camera.main.transform.position = camPos;
	}

	void GenEnemy(int e1, int e2){
		for(int i = 0; i < e1; i++){
			Vector3 ePos = new Vector3 (Random.Range(-mapWidth/2, mapWidth/2), 1f, Random.Range(-mapHeight/2, mapHeight/2));
			Instantiate(enemy1Prefab, ePos, Quaternion.identity);
		}
		for(int i = 0; i < e2; i++){
			Vector3 ePos = new Vector3 (Random.Range(-mapWidth/2, mapWidth/2), 1f, Random.Range(-mapHeight/2, mapHeight/2));
			Instantiate(enemy2Prefab, ePos, Quaternion.identity);
		}
	}



	void GenWalls (){
		GameObject wall1 = Instantiate(wallPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		wall1.SetActive(false);
		wall1.transform.Translate(new Vector3 ((float)mapWidth / 2, 0f, 0f));
		wall1.transform.localScale = new Vector3 (0.5f, 3f, (float)mapHeight+ 0.5f) ;
		wall1.SetActive(true);

		GameObject wall2 = Instantiate(wallPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		wall2.SetActive(false);
		wall2.transform.Translate(new Vector3 (-(float)mapWidth / 2, 0f, 0f));
		wall2.transform.localScale = new Vector3 (0.5f, 3f, (float)mapHeight+ 0.5f) ;
		wall2.SetActive(true);

		GameObject wall3 = Instantiate(wallPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		wall3.SetActive(false);
		wall3.transform.Translate(new Vector3 (0f, 0f, (float)mapHeight / 2));
		wall3.transform.localScale = new Vector3 ((float)mapWidth+ 0.5f, 3f, 0.5f) ;
		wall3.SetActive(true);

		GameObject wall4 = Instantiate(wallPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		wall4.SetActive(false);
		wall4.transform.Translate(new Vector3 (0f, 0f, -(float)mapHeight / 2));
		wall4.transform.localScale = new Vector3 ((float)mapWidth+ 0.5f, 3f, 0.5f) ;
		wall4.SetActive(true);

		GameObject floor = Instantiate(floorPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		floor.SetActive(false);
		floor.transform.Rotate(90f, 0f, 0f);
		floor.transform.localScale = new Vector3 (mapWidth, mapHeight, 1f);
		floor.SetActive(true);
	}
}
