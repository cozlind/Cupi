using UnityEngine;
using System.Collections;

public class Leveldoor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Cupi") {
			Globe.loadName="Scene2";
			Globe.loadSite=0;
			Application.LoadLevelAsync ("LoadingScene");
		}
	}
}
