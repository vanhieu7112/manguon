using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayController : MonoBehaviour {
	public static GamePlayController instance;
	[SerializeField]
	private GameObject PausePanel;
	[SerializeField]
	private GameObject gameOverPanel;
	[SerializeField]
	private Button continueGame;
	[SerializeField]
	private Button restartGame;
	[SerializeField]
	private Button menuGame;
	[SerializeField]
	private Text scoreText,endScore,bestScore;
	[SerializeField]
	private GameObject heart1, heart2, heart3;
	public void Awake()
	{
		Time.timeScale = 1f;
		_MakeInstance ();
	}
	void _MakeInstance(){
		if (instance == null) {
			instance = this;
		}
	}
	public void PauseGame()
	{
		Time.timeScale = 0f;
		PausePanel.SetActive (true);
		continueGame.onClick.RemoveAllListeners ();
		continueGame.onClick.AddListener(()=>ResumeGame());
	}
	public void ResumeGame()
	{
		Time.timeScale = 1f;
		PausePanel.SetActive (false);
	}
	public void RestartGame(){
		Time.timeScale = 1f;
		Application.LoadLevel ("GamePlay");
	}

	public void PlayerDied(int score){
		Time.timeScale = 0f;
		gameOverPanel.SetActive (true);
		endScore.text = "" + score;
		if (score > GameManager.instance.GetHighScore ()) {
			GameManager.instance.SetHighScore (score);
		}
		bestScore.text =""+ GameManager.instance.GetHighScore ();
		restartGame.onClick.RemoveAllListeners ();
		restartGame.onClick.AddListener(()=>RestartGame());
	}
	public void _SetScore(int score){
		scoreText.text = score.ToString ();
	}
	public void MenuGame(){
		Application.LoadLevel ("MainMenu");
	}
	public void Live(int live)
	{
		if (live == 3) {
			heart3.SetActive (true);
			heart2.SetActive (true);
			heart1.SetActive (true);
		} 
		if (live == 2) {
			heart3.SetActive (false);
			heart2.SetActive (true);
			heart1.SetActive (true);
		} 
		if (live == 1) {
			heart3.SetActive (false);
			heart2.SetActive (false);
			heart1.SetActive (true);
		} 
		if(live==0){
			heart3.SetActive (false);
			heart2.SetActive (false);
			heart1.SetActive (false);
		}
	}
}
