using UnityEngine;
using System.Collections;

public class CupController : MonoBehaviour {

	public float moveSpeed=7f;
	public float jumpVelocity=40f;
	public float jumpTime=0.8f;
	public float adjustTime=1f;

	public static int gameState;
	public const int STATE_IDLE=0;
	public const int STATE_WALK=1;
	public const int STATE_JUMP=2;

	private bool stateLock=false;
	private enum Lock{LOCK_NONE,LOCK_IDLE,LOCK_WALK,LOCK_JUMP};
	private Lock actionLock;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//physical adjustment
		if (transform.rotation.z > 35 || transform.rotation.z < -35)
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, 0), adjustTime);

		//respond to input
		if (Input.GetKey (KeyCode.A)) {
			if(!stateLock){
				gameState=STATE_WALK;
			}
			if(actionLock!=Lock.LOCK_WALK){
				transform.localScale=new Vector3(-Mathf.Abs(transform.localScale.x),1,1);
				GetComponent<Rigidbody2D>().velocity=new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		else if (Input.GetKey (KeyCode.D)) {
			if(!stateLock){
				gameState=STATE_WALK;
			}
			if(actionLock!=Lock.LOCK_WALK){
				transform.localScale=new Vector3(Mathf.Abs(transform.localScale.x),1,1);
				GetComponent<Rigidbody2D>().velocity=new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		else{
			if(!stateLock){
				gameState=STATE_IDLE;
			}
		}
		if(Input.GetKeyDown (KeyCode.Space)){
			if(!stateLock){
				gameState=STATE_JUMP;
				stateLock=true;
			}
			if(actionLock!=Lock.LOCK_JUMP){
				GetComponent<Rigidbody2D>().velocity=new Vector2(transform.localScale.x/Mathf.Abs(transform.localScale.x),jumpVelocity);//horizontal move
				actionLock=Lock.LOCK_JUMP;
				StartCoroutine(delay_Action(jumpTime));
			}
		}
	}
	IEnumerator delay_Action(float delayTime){
		yield return new WaitForSeconds (jumpTime);
		stateLock = false;
		actionLock = Lock.LOCK_NONE;
	}

}
 