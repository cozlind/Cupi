using UnityEngine;
using System.Collections;

public class CupAnimeController : MonoBehaviour {
	protected Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if(animator)
		{
			animator.SetInteger("CupAnime",CupController.gameState);
		}


	}
}