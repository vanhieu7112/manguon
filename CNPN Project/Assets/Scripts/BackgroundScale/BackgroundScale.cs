using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();//Tính biên
		Vector3 tempScale = transform.localScale;//Lấy scale hiện tại của background;

		float height = sr.bounds.size.y;//Lấy biên hiện tại(chiều cao);
		float width = sr.bounds.size.x;
		float worldHeight = Camera.main.orthographicSize * 2f; //10;
		float worldWidth = worldHeight * Screen.width / Screen.height;// 10 * chieurong/chieucao dang su dung hien tai cua background;


		transform.localScale = new Vector3 (worldWidth, worldHeight, 0);
		tempScale.y = worldHeight / height;//background đụng vào Camera sẽ ngưng;
		tempScale.x = worldWidth / width;
		transform.localScale = tempScale;//Gán ngược lại cho BG;
	}
		

}
