using UnityEngine;
using System.Collections;

public class Logic : Singleton <Logic> {

	bool gameMod1;
	bool gameMod2;

	public GameObject Mod1Player;
	public GameObject Mod2Player;
	public Game thisGame;

	GameMod_1_LevelGenerator gMod1Gen;
	GameMod_2_LevelGenerator gMod2Gen;
	WorldGenerator worldGen;

	//for world generator
	public int starCount;
	public float mapSize;
	public float starRadius;
	//world gen end

	void Start () {
		DontDestroyOnLoad(gameObject);
		worldGen = WorldGenerator.Instance;
		gMod1Gen = GameMod_1_LevelGenerator.Instance;
		gMod2Gen = GameMod_2_LevelGenerator.Instance;
		gameMod1 = false;
		gameMod2 = false;
	}

	void Update () {

	}

	void StartMod1 (){
		gameMod1 = true;
		Star star = thisGame.map.GetPlayerPositionStar();
		gMod1Gen.GenLevel(star);
		gMod1Gen.player = Instantiate(Mod1Player, Vector3.zero, Quaternion.identity) as GameObject;
	}

	void EndMod1 (){
		gameMod1 = false;
		gMod1Gen.DestroyLevel();
		Mod1Player.SetActive(false);
	}

	void NewGame (){
		thisGame = new Game();
		thisGame.map = worldGen.GenNewWorldMap (starCount, mapSize, starRadius);
		Application.LoadLevel("Map");
	}

	void LoadGame(){
		Debug.Log ("Here must be load game");
	}

	void Quit(){
		Debug.Log ("Quit");
		Application.Quit();
	}
}
