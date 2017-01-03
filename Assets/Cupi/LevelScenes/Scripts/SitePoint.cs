using UnityEngine;
using System.Collections;

public class SitePoint : MonoBehaviour {
	private bool getPoint;
	public int Num=0;
	void Start(){
		if (Globe.loadSite >= Num)
			getPoint = true;
		else getPoint = false;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Cupi"&&!getPoint) {
			Globe.loadSite=Num;
			PlayerPrefs.SetInt ("Player"+Globe.loadNum+"Site",Num);
		}
	}
}
