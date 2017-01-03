using UnityEngine;
using System.Collections;

public class BalanceStick : MonoBehaviour {
	public static bool collisionCamera = false;
	public static bool reset = false;
	public GameObject penCollumn;
	void Start(){
		collisionCamera = false;
		reset = false;
	}
	void Update(){
		if (reset) {
						transform.position = new Vector3 (61.777f, -32.28f, 0);
						transform.rotation = Quaternion.Euler (Vector3.zero);
						gameObject.GetComponent<Rigidbody2D>().velocity=Vector2.zero;

						penCollumn.transform.position = new Vector3 (44.056f, -26.254f, 0);
						penCollumn.GetComponent<Rigidbody2D>().velocity=Vector2.zero;
						transform.rotation = Quaternion.Euler (Vector3.zero);
						reset=false;
				}
		if (penCollumn.transform.position.y <= -30f) {
			collisionCamera=false;		
		}
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Cupi") {
			collisionCamera=true;
		}
	}
}
