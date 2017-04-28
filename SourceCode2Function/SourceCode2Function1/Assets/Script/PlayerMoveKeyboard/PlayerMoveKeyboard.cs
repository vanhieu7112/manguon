using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {

	//DK Nhan vat
	public float speed1 =10f;
	public float maxVelocity1 =8f;
	[SerializeField]
	private Rigidbody2D myBody;
	[SerializeField]
	private Animator anim;

	[SerializeField]
	private AudioSource audioPlayer;
	[SerializeField]
	private AudioClip coinClip, sackClip, RockClip, BombClip;
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
			if (vel < maxVelocity1)//van toc hien tai < ..
				forceX = speed1;
			Vector3 temp = transform.localScale;//cai huong cua nhan vat;hehe
			temp.x = 2.5f;
			transform.localScale = temp;
			anim.SetBool ("Walk", true);
		} else if (h < 0) {
			if (vel < maxVelocity1)

				forceX = -speed1;
			Vector3 temp = transform.localScale;
			temp.x = -2.5f;
			transform.localScale = temp;
			anim.SetBool ("Walk", true);
		} else {
			anim.SetBool ("Walk", false);
		}
		myBody.AddForce (new Vector2 (forceX, 0));//ham AddForce tao ra 1 luc day theo huong vector
	}
	void OnTriggerEnter2D(Collider2D target)//Duoc sd khi ma co 1 trong 2 doi tuong co su dung isTrigger//isTrigger:true va cham trigger(di xuyen qua),false:va cham collision(can lai)
	{
		if (target.tag == "Bomb") {
				
			audioPlayer.PlayOneShot (BombClip);
				Destroy (target.gameObject);
				
		} else if (target.tag == "CoinSack") {
			audioPlayer.PlayOneShot (sackClip);//them audioclip vao audiosoure 
			Destroy (target.gameObject);
		} else if(target.tag=="Heart"){
			Destroy(target.gameObject);
		}else if(target.tag=="Rock"){
			audioPlayer.PlayOneShot (RockClip);
			Destroy(target.gameObject); 

		}else{	

			audioPlayer.PlayOneShot (coinClip);
			Destroy(target.gameObject);
		}
	}
}
