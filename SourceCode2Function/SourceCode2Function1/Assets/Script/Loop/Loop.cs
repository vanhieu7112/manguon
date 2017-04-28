using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Loop : MonoBehaviour {
	[SerializeField]
	private GameObject itemsp;
	[SerializeField]
	private GameObject itemspp;
	[SerializeField]
	private GameObject item;
	[SerializeField]
	private GameObject items;
	[SerializeField]
	private GameObject items1;
	[SerializeField]
	private GameObject items2;
	[SerializeField]
	private GameObject items3;
	[SerializeField]
	private GameObject items4;
	[SerializeField]
	private GameObject items5;
	[SerializeField]
	private GameObject items6;
	[SerializeField]
	private GameObject items7;
	//tao ra cac vat pham lien tuc

	IEnumerator Attack(){

		yield return new WaitForSeconds (Random.Range(1,2));//chờ trong khoang 1->2 s
		Vector3 temp = items.transform.position;//Chon vi tri hien tai cua obj;
		temp.x = Random.Range (-8.40f,8.20f);
		temp.y = 5.82f;
		Instantiate (items,temp, Quaternion.identity);//sau đó sinh ra 1 lần rồi hết


		Vector3 tempp = itemsp.transform.position;
		tempp.x = Random.Range (-8.40f,8.20f);
		tempp.y = 5.82f;
		Instantiate (itemsp,temp, Quaternion.identity);



		Vector3 temp1 = items1.transform.position;
		temp1.x = Random.Range (-8.40f,8.20f);
		temp1.y = 5.82f;
		Instantiate (items1,temp1, Quaternion.identity);


		Vector3 temp3 = items3.transform.position;
		temp3.x = Random.Range (-8.40f,8.20f);
		temp3.y = 5.82f;
		Instantiate (items3,temp3, Quaternion.identity);

		Vector3 temp4 = items4.transform.position;
		temp4.x = Random.Range (-8.40f,8.20f);
		temp4.y = 5.82f;
		Instantiate (items4,temp4, Quaternion.identity);

		Vector3 temp6 = items6.transform.position;
		temp6.x = Random.Range (-8.40f,8.20f);
		temp6.y = 5.82f;
		Instantiate (items6,temp6, Quaternion.identity);
		StartCoroutine (Attack ());//sinh ra lại

	}
	IEnumerator Attack1(){
		yield return new WaitForSeconds (Random.Range(2,3));//chờ trong khoang 1->2 s
		Vector3 temppp = itemspp.transform.position;
		temppp.x = Random.Range (-8.40f,8.20f);
		temppp.y = 5.82f;
		Instantiate (itemspp,temppp, Quaternion.identity);

		Vector3 temp2 = items2.transform.position;
		temp2.x = Random.Range (-8.40f,8.20f);
		temp2.y = 5.82f;
		Instantiate (items2,temp2, Quaternion.identity);

		Vector3 temp5 = items5.transform.position;
		temp5.x = Random.Range (-8.40f,8.20f);
		temp5.y = 5.82f;
		Instantiate (items5,temp5, Quaternion.identity);
		StartCoroutine (Attack1 ());//sinh ra lại

	}
	IEnumerator Attack2(){
		yield return new WaitForSeconds (Random.Range(30,60));//chờ trong khoang 1->2 s
		Vector3 temp7 = items7.transform.position;
		temp7.x = Random.Range (-8.40f,8.20f);
		temp7.y = 5.82f;
		Instantiate (items7,temp7, Quaternion.identity);
		StartCoroutine (Attack2 ());//sinh ra lại
	}

	void Start () {

		StartCoroutine (Attack ());
		StartCoroutine (Attack1 ());
		StartCoroutine (Attack2 ());
	}


}
