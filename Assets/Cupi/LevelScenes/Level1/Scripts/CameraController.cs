using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Transform target;
	public float x_aboveTarget=2f;
	public float y_aboveTarget=3f;
	public float damping = 2f;
	public float zoomDamping=1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.Find ("Cup").transform;
	//	float currentX = target.position.x+x_aboveTarget;
		float currentX = Mathf.Lerp (transform.position.x, target.position.x + x_aboveTarget, damping * Time.deltaTime);
		float currentY = Mathf.Lerp (transform.position.y, target.position.y + y_aboveTarget, damping * Time.deltaTime);//smooth follow


		float currentSize;

		if (UpwardBlockSwitch.switchOn) {
						currentSize = Mathf.Lerp (gameObject.GetComponent<Camera> ().orthographicSize, 24, zoomDamping * Time.deltaTime);
						y_aboveTarget = 14f;
						x_aboveTarget = 14f;
						damping = 1f;
				} else if (LightSwitch.lightSwitchCamera) {				
						currentSize = Mathf.Lerp (gameObject.GetComponent<Camera> ().orthographicSize, 24, zoomDamping * Time.deltaTime);
						y_aboveTarget = 20f;
						x_aboveTarget = -5f;
						damping = 1f;
				} else if (BalanceStick.collisionCamera) {
						currentSize = Mathf.Lerp (gameObject.GetComponent<Camera> ().orthographicSize, 29, zoomDamping * Time.deltaTime);
						y_aboveTarget = 25f;
						x_aboveTarget = -5f;
						damping = 1f;
				} else { 
						currentSize = Mathf.Lerp (gameObject.GetComponent<Camera> ().orthographicSize, 14, zoomDamping * Time.deltaTime);
						y_aboveTarget=3f;
						x_aboveTarget=2f;
						damping=2f;		
		}
		gameObject.GetComponent<Camera>().orthographicSize=currentSize;
		transform.position = new Vector3 (currentX, currentY, transform.position.z);
	}
}
