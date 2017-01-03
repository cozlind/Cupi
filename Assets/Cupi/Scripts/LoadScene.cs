using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	AsyncOperation async;
	// Use this for initialization
	void Start () {
		StartCoroutine (loadScene ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator loadScene()
	{
		async=Application.LoadLevelAsync (Globe.loadName);
		yield return async;
	}
}
