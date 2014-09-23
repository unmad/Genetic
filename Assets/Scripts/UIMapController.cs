using UnityEngine;
using System.Collections;

public class UIMapController : Singleton <UIMapController> {


	public Logic logic;
	public GameObject upUI;
	public GameObject map;
	public GameObject research;
	public GameObject inventory;
	public GameObject planet;

	void Start (){
		logic = Logic.Instance;
		foreach(var star in logic.thisGame.map.stars){
			Instantiate(planet,new Vector3(star.position.x, star.position.y, 0f), Quaternion.identity);
		}
	}

	public void ShowUpUI(){
		HideAll();
		upUI.SetActive(true);
	}

	public void ShowMap(){
		HideAll();
		map.SetActive(true);
	}

	public void ShowInventory(){
		HideAll();
		inventory.SetActive(true);
	}

	public void ShowShipInv(){

	}

	public void ShowHeroInv(){
		
	}

	public void ShowResearch(){
		HideAll();
		research.SetActive(true);
	}

	public void HideAll(){
		//upUI.SetActive(false);
		map.SetActive(false);
		research.SetActive(false);
		inventory.SetActive(false);
	}
}
