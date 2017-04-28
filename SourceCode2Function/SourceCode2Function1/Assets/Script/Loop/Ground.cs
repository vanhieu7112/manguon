using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
		if (target.tag == "Ground") {
			Destroy (gameObject);//no tu hieu la cai file itemsScript nay
			//con target.gameObject thi no tu heiu la cai Ground. cua thang nao magn cai tag la gROUND A'
		}
	}
}
