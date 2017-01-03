using UnityEngine;
using System.Collections;

public class UpwardAndDownwardBlock : MonoBehaviour {

	public GameObject front;
	public float middleY=-50f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		//front.transform.Translate (Vector3.up);
		front.transform.localPosition = new Vector2(front.transform.localPosition.x,middleY*2-transform.localPosition.y);
	}
}
