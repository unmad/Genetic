using UnityEngine;
using System.Collections;

public class HpMeneger: MonoBehaviour {

	int hp;
	public int maxHp;

	void Start () {
		hp = maxHp;
	}
	
	void Update () {

	}

	public void SetDemage(int i){
		hp -= i;
		Debug.Log("hp - " + i);
		if (hp < 1)
			SendMessage("Die");

	}
}
