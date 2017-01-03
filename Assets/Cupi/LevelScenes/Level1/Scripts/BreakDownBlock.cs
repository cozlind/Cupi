using UnityEngine;
using System.Collections;

public class BreakDownBlock : MonoBehaviour {
	public int times=10;
	private bool collisionLock = false;
	
	void OnCollisionExit2D(Collision2D coll) {
		if(coll.gameObject.tag=="Cupi"&&CupController.gameState == CupController.STATE_JUMP){
			times--;
			if (times<3&&!collisionLock) {
				transform.RotateAround(new Vector3(-0.1f,0.4f,0), -Vector3.forward, 20);
				collisionLock=true;
			}
		}
	}
}
