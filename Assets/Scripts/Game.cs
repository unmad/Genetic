using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Game {
	public Map map;
	public ResearchMap researchMap;
	public Inventory inventory;
	public Ress ress;
}

public class Star {

	public int lvl; //сложность
	public int type;
	public Vector2 position; //в мире
	public int mod1EenemyType1; //тип противников mod1
	public int mod1EenemyType2;
	public bool mod1Boss;
	public bool mod1BossType; //if true type1
	public Vector2 mod1MapSize;
	public int mod2EnemyType1; //тип противников mod2
	public int mod2EnemyType2;
	public bool mod2Boss;
	public bool mod2BossType; //if true type2
	public float mod2MapSize;
	public bool playerHere;
	public bool clear;
}

public class Research {
	public int progress;
	public bool enabled;
	public bool end;
}

public class ResearchBranch{
	public Research[] researchBranch;
}

public class ResearchMap {
	public ResearchBranch[] researchMap;
}

public class Inventory {
	public int mod1Weapon;
	public int mod1Armor;
	public int mod1Legs;
	public int mod2Weapon;
	public int mod2Armor;
	public int mod2Type;
}

public class Ress {
	public int bio;
	public int tech;
}

public class Map {
	public List<Star> stars;

	public Star GetPlayerPositionStar(){
		foreach (Star star in stars){
			if (star.playerHere)
				return star;
		}
		return null;
	}
}