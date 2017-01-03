using UnityEngine;
using System.Collections;

public class UpwardBlock : MonoBehaviour {
	public static bool startWork = false;
	public float upspeed=6F;
	public int stopTime=10;
	public float downspeed=3f;
	public float waitTime=6f;

	private int i=0;
	public bool up;
	public bool stop;
	public bool down;
	// Use this for initialization
	void Start () {
		startWork=false;
		stop=false;
		down=false;
	}
	
	// Update is called once per frame
	void Update () {

		if (startWork) {	
			StartCoroutine( delay_Action(waitTime));
			}

		if (up) {
		StopAllCoroutines();
			GetComponent<Rigidbody2D>().velocity=new Vector2(0,upspeed);
			if(transform.position.y>=-9.5f){
				up=false;
				GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
				stop=true;
				i=0;
			}
		}
		if (stop) {
			i++;
			if(i>=stopTime){
				stop=false;
				down=true;
			}
		}
		if (down) {
			GetComponent<Rigidbody2D>().velocity=new Vector2(0,-downspeed);
			//transform.Translate (Vector3.up*Time.deltaTime*(-downspeed));
			if(transform.position.y<=-43){
				GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
				down=false;
				UpwardBlockSwitch.switchOn=false;
			}			
		}
	}
	IEnumerator delay_Action (float delayTime){
		yield return new WaitForSeconds (delayTime);
		up = true;
		startWork = false;		//transform.Translate (Vector3.up*Time.deltaTime*upspeed);
	}
	//void OnCollisionStay2D(Collision2D coll) {
	//	if(coll.gameObject.tag=="Cupi"&&startWork){
		//	coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,force));
			//coll.gameObject.transform.position=new Vector3(coll.gameObject.transform.position.x,gameObject.transform.position.y+1.2f,coll.gameObject.transform.position.z);
	//	}
	//}
}
