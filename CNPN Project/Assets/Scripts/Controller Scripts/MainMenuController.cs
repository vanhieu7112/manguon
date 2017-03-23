using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour {
	public static GamePlayController instance;
	[SerializeField]
	private GameObject panel;
	[SerializeField]
	private GameObject button1, button2;
	[SerializeField]
	private Text highScore;

	public void HighScorePanel()
	{
		panel.SetActive (true);
		button1.SetActive (false);
		button2.SetActive (false);
		highScore.text = "" + GameManager.instance.GetHighScore ();//Gan diem cho highscore.
	}
	public void MainMenu(){
		Application.LoadLevel ("MainMenu");
	}
	public void StartGame(){
		
		Application.LoadLevel ("GamePlay");
	
	}
	void Update(){
		Time.timeScale = 1f;//De khi ma vao lai scenes GamePlay lan nua thi no tu dong chay.
	}
}
