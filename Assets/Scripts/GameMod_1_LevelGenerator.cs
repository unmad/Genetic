using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMod_1_LevelGenerator : Singleton <GameMod_1_LevelGenerator> {

	public GameObject enemy1Prefab;
	public GameObject enemy2Prefab;
	public GameObject wallPrefab;
	public GameObject floorPrefab;
	public int mapWidth;
	public int mapHeight;
	public float borderSize;
	public GameObject player;
	//public int countOfEnemy1;
	//public int countOfEnemy2;

	GameObject floor;
	GameObject[] walls;
	List<GameObject> enemy;
	
	void Start () {

	}

	void Update () {
	
	}

	public void GenLevel(Star star){
		GenWalls(star);
		GenEnemy(star);
	}

	void GenEnemy(Star star){
		enemy = new List<GameObject>();

		for(int i = 0; i < star.lvl; i++){
			Vector3 ePos = new Vector3 (Random.Range(-star.mod1MapSize.x / 2, star.mod1MapSize.x / 2), 1f, Random.Range(-star.mod1MapSize.y / 2, star.mod1MapSize.y/2));
			GameObject ene = Instantiate(enemy1Prefab, ePos, Quaternion.identity) as GameObject;
			enemy.Add(ene);
		}

		for(int i = 0; i < star.lvl; i++){
			Vector3 ePos = new Vector3 (Random.Range(-star.mod1MapSize.x / 2, star.mod1MapSize.x / 2), 1f, Random.Range(-star.mod1MapSize.y/2, star.mod1MapSize.y/2));
			GameObject ene = Instantiate(enemy2Prefab, ePos, Quaternion.identity) as GameObject;
			enemy.Add(ene);
		}
	}

	void GenWalls (Star star){
		walls = new GameObject[4];

		walls[0] = GenWall(new Vector4 (star.mod1MapSize.x / 2, 0f, 0.5f, star.mod1MapSize.y + 0.5f));
		walls[1] = GenWall(new Vector4 (-star.mod1MapSize.x / 2, 0f, 0.5f , star.mod1MapSize.y + 0.5f));
		walls[2] = GenWall(new Vector4 ( 0f, star.mod1MapSize.y / 2, star.mod1MapSize.x + 0.5f, 0.5f));
		walls[3] = GenWall(new Vector4 ( 0f, -star.mod1MapSize.y / 2, star.mod1MapSize.x + 0.5f, 0.5f));
		
		GameObject floor = Instantiate(floorPrefab, new Vector3 (0f, 0f, 0f), Quaternion.identity) as GameObject;
		floor.SetActive(false);
		floor.transform.Rotate(90f, 0f, 0f);
		floor.transform.localScale = new Vector3 (star.mod1MapSize.x + 50, star.mod1MapSize.y + 50, 1f);
		floor.SetActive(true);
		floor.renderer.material.SetTextureScale("_MainTex" , new Vector2 (star.mod1MapSize.x / 15, star.mod1MapSize.y / 15));
		Debug.Log(floor.renderer.material.GetTextureScale("_MainTex"));
	}
	
	GameObject GenWall(Vector4 size){  //size xy- pos zw- size
		GameObject wall = Instantiate(wallPrefab, new Vector3 (size.x, 0f, size.y), Quaternion.identity) as GameObject;
		wall.SetActive(false);
		wall.transform.localScale = new Vector3 (size.z, 3f,size.w) ;
		wall.SetActive(true);
		return wall;
	}

	public void DestroyLevel(){
		foreach (GameObject wall in walls){
			if (wall != null){
				Destroy(wall);
			}
		}

		foreach (GameObject ene in enemy){
			if (ene != null){
				Destroy(ene);
			}
		}

		Destroy(floor);
	}
}