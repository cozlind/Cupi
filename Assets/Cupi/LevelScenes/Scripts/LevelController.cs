using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public GameObject Cup;
	// Use this for initialization
	void Start () {
		putCharater();
		MainMenu.menuPermission = false;
		Time.timeScale=1;
		/*playerName = "小明";
		playerNum = 0;
		scrollPosition = Vector2.zero;
		musicVolume = PlayerPrefs.GetFloat ("musicVolume", 70);
		soundVolume = PlayerPrefs.GetFloat ("soundVolume", 70);
		difficulty = PlayerPrefs.GetInt ("difficulty", 2);*/
	}
	
	// Update is called once per frame
	void Update () {
		MainMenu.mainMenu=false;

		if (Input.GetKeyDown (KeyCode.R)) {
			putCharater();
			BalanceStick.reset=true;
			LightSwitch.lightSwitchCamera=false;
			BalanceStick.collisionCamera=false;
		}
		else if(Input.GetKeyDown (KeyCode.Escape)){
			if(Time.timeScale==1){
				Time.timeScale=0;
				MainMenu.menuPermission=true;
			}
			else if(Time.timeScale==0){
				Time.timeScale=1;
				MainMenu.menuPermission=false;
			}
		}
	}
	void putCharater(){
		if(GameObject.Find ("Cup")) Destroy (GameObject.Find ("Cup"));
		Object cup=Instantiate (Cup,GameObject.Find ("Site"+Globe.loadSite).transform.position, Quaternion.identity);
		cup.name = "Cup";
	}
}
