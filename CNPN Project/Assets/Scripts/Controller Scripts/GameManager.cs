using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	private const string highScore="";
	void Awake(){
		_MakeSingleInstance ();
		IsGameStartedForTheFirstTime ();
	}

	void IsGameStartedForTheFirstTime(){//Game này đã tải về lần đầu tiên chưa, mac đinh la false
		if (!PlayerPrefs.HasKey ("IsGameStartedForTheFirstTime")) {//là nếu như ng dùng mới  tải về lần đầu thì nó la true, nhưng  mầ mặc định la false nen phải đăt !;
			PlayerPrefs.SetInt (highScore, 0);//reset diem ve 0 ;
			PlayerPrefs.SetInt("IsGameStartedForTheFirstTime",0); // bool 0 la false , 1 la true, neu la 1 nhung do vât đã unlock thì no sẽ xoa hêt , nên để 0 là nó giữ lại
		}
	}
	void _MakeSingleInstance(){//van giu duoc cai gameObject nay khi ma minh muon dieu huong sang cai scenes kkac
		if(instance!=null)
		{
			Destroy(gameObject);//chinh vi no khac null ,tuc la da co roi nen moi destroy cai ban sao.
		}else{
			instance=this;//bang cai class GameManager nen no khong cho destroy duoc nen phai dung if
			DontDestroyOnLoad(gameObject);//khong bi huy khi ma load len cai scenes khac.
		}
	}
	public void SetHighScore(int score)//cho di
	{
		PlayerPrefs.SetInt (highScore, score);//de luu tru bat cu thanh phan nao trong game thi dung PlayerPreference. luu diem kieu so  SetIn,.. key/value truyen value vo key
		//luc truyen cai score vo cho highScore xong thi đồng thời nó reset cai score về 0 luôn.
	}
	public int GetHighScore(){//nhan ve
		return PlayerPrefs.GetInt(highScore);//truy xuat thong tin
	}

}
