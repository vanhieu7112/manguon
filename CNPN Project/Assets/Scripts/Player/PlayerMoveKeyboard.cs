using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {
	
	//DK Nhan vat
	public float speed =8f;
	public float maxVelocity =10f;
	[SerializeField]
	private Rigidbody2D myBody;
	[SerializeField]
	private Animator anim;
	public int score = 0;

	[SerializeField]
	private AudioSource audioPlayer;
	[SerializeField]
	private AudioClip coinClip, sackClip, diedClip;
	private int live=2;

	void Awake(){
		
		myBody = GetComponent<Rigidbody2D> ();//Lay cai rigidbody ra;
		anim = GetComponent<Animator> ();
	}


	void FixedUpdate () { //co physics thi dung FixedUpdate
		
		PlayerMoveKey ();
	}
	public void PlayerMoveKey()
	{
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal"); // > 0 right, <0 left;
		if (h > 0) {
			if (vel < maxVelocity)//van toc hien tai < ..
			forceX = speed;
			Vector3 temp = transform.localScale;//cai huong cua nhan vat;hehe
			temp.x = 2;
			transform.localScale = temp;
			anim.SetBool ("Walk", true);
		} else if (h < 0) {
			if (vel < maxVelocity)
				
			forceX = -speed;
			Vector3 temp = transform.localScale;
			temp.x = -2;
			transform.localScale = temp;
			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}
		myBody.AddForce (new Vector2 (forceX, 0));//ham AddForce tao ra 1 luc day theo huong vector
	}
	void OnTriggerEnter2D(Collider2D target)//Duoc sd khi ma co 1 trong 2 doi tuong co su dung isTrigger
	{
		if (target.tag == "Bomb") {	
			live--;
			if (live >= 1) {
				GamePlayController.instance.Live (live);
				Destroy (target.gameObject);
			}else
			{
				Destroy (gameObject);//Pha huy muc tieu Player;	
				GamePlayController.instance.Live (live);
				GameObject.Find ("GamePlayController").GetComponent<GamePlayController> ().PlayerDied(score);//GameObject.Find la tim den cai GamePlayController hay noi cach khac no dung de tim kiem den cai GameObject nao do.
				Destroy (GameObject.Find ("Loop"));//xoa doi tuong la loop
			}

		} else 	if (target.tag == "CoinSack") {
			audioPlayer.PlayOneShot (sackClip);//them audioclip vao audiosoure 
			score = score + 3;
			GamePlayController.instance._SetScore (score);//b3a(GamePlayController) gan diem cho no
			Destroy (target.gameObject);
		} else if(target.tag=="Heart"&&live<3){
			live++;
			GamePlayController.instance.Live (live);
			Destroy (target.gameObject);
		} else{	

			audioPlayer.PlayOneShot (coinClip);

			score++;		
			GamePlayController.instance._SetScore (score);
			Destroy (target.gameObject);
		}
	}
}
