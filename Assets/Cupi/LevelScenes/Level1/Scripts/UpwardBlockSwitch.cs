using UnityEngine;
using System.Collections;

public class UpwardBlockSwitch : MonoBehaviour {
	// Use this for initialization
	public Sprite switch1;
	public Sprite switch2;
	public static bool switchOn=false;

	void Start(){
		gameObject.GetComponent<SpriteRenderer>().sprite=switch1;
	}
	void OnCollisionStay2D(Collision2D coll) {
		if(coll.gameObject.tag=="Cupi"&&Input.GetKeyDown(KeyCode.U)){
			switchOn=true;//控制自己切换精灵贴图
			UpwardBlock.startWork=true;//控制受控对象启动行为
		}
	}
	void Update(){
		if (!switchOn) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = switch1;
				}
		else {
			gameObject.GetComponent<SpriteRenderer>().sprite=switch2;
		}
	}
}