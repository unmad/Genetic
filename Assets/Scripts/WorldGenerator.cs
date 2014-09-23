using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldGenerator : Singleton<WorldGenerator> {

	public GameObject[] starsPrefabs;
	public GameObject[] mod1EnemyPrefabs;
	public GameObject[] mod2EnemyPrefabs;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Map GenNewWorldMap(int starsCount, float mapSize, float starRadius){
		Map map = new Map();
		map.stars = new List<Star>();

		for (var i = 0; i < starsCount; i++){
			Vector2 NewStarPos = Random.insideUnitCircle * mapSize;
			Star star = new Star();
			star.lvl = 1; //сложность
			star.type = Random.Range(0, 3);
			star.position = NewStarPos; //в мире
			star.mod1EenemyType1 = Random.Range(0, 9); //тип противников mod1
			star.mod1EenemyType2 = Random.Range(0, 9);
			star.mod1Boss = false;
			star.mod1BossType = false; //if true type1
			star.mod1MapSize = new Vector2 (star.lvl * 50, star.lvl * 50);
			star.mod2EnemyType1 = Random.Range(0, 9); //тип противников mod2
			star.mod2EnemyType2 = Random.Range(0, 9);
			star.mod2Boss = false;
			star.mod2BossType = false; //if true type2
			star.mod2MapSize = star.lvl * 10;
			star.clear = false;
			star.playerHere = false;
			map.stars.Add(star);
		}

		int playerAt = Random.Range(0, starsCount);

		Debug.Log(playerAt + " playerAt " + map.stars[playerAt].position);
		map.stars[playerAt].playerHere = true;
		return map;
	}
}
