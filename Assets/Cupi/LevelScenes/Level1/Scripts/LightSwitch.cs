using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour {

	public Sprite switch1;
	public Sprite switch2;
	public Sprite bulb_off;
	public Sprite bulb_on;
	public static bool switchOn=false;
	public static bool lightSwitchCamera=false;
	public GameObject bulb;
	public GameObject lightBridge;
	public GameObject lightSwitch;


	void Start(){
		lightSwitch.GetComponent<SpriteRenderer>().sprite=switch1;
		lightSwitchCamera=false;
		switchOn=false;
	}
	void OnTriggerStay2D(Collider2D other) {
				if (other.gameObject.tag == "Cupi" && Input.GetKey (KeyCode.U)) {
						switchOn = !switchOn;//控制自己切换精灵贴图
						lightSwitchCamera = true;
				}
		}
	void OnTriggerExiter2D(Collider2D other){
			if (other.gameObject.tag == "Cupi")
						lightSwitchCamera = false;
		}
	void Update(){
		if (!switchOn) {
			lightSwitch.GetComponent<SpriteRenderer> ().sprite = switch1;
			bulb.GetComponent<SpriteRenderer>().sprite=bulb_off;
			lightBridge.SetActive(false);
		}
		else {
			lightSwitch.GetComponent<SpriteRenderer>().sprite=switch2;
			bulb.GetComponent<SpriteRenderer>().sprite=bulb_on;
			lightBridge.SetActive(true);
		}
	}
}

