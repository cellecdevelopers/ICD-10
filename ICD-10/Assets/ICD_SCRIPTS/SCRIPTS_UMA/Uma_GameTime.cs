using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uma_GamTime : MonoBehaviour {

	#region Data Declarations
	public GameObject GameOverScreen;
	public GameObject Game;
	public bool Doit =false;
	int startTime;
	float time;
	public float timeSpeed;
	public int TimeStart;
	#endregion

	#region StartFunction
	void Start()
	{
		if(PlayerPrefs.GetInt(PlayerPrefs.GetString("Mode")+"_"+"LevelNumber")<=11)
			startTime = TimeStart - (PlayerPrefs.GetInt(PlayerPrefs.GetString("Mode")+"_"+"LevelNumber")-1) * 5;
		time = 0;
	}
	#endregion

	#region UpdateFunction
	void Update()
	{
		int diff = startTime - Mathf.FloorToInt(time);
		if(Doit&&diff >= -1&&Time.timeScale == 1.0f)
		{
			time = time + timeSpeed;
			GetComponent<Text>().text = diff.ToString();

			if(diff < 0)
			{
				Doit = false;
				CloseThis();
			}
		}
		
	}
	#endregion

	#region GameOverFunction
	public void CloseThis()
	{
		float totalTime = 0;
		for(int i =0;i<PlayerPrefs.GetInt(PlayerPrefs.GetString("Mode")+"_"+"LevelNumber");i++)
		{
			totalTime = totalTime + TimeStart - (PlayerPrefs.GetInt(PlayerPrefs.GetString("Mode")+"_"+"LevelNumber")-1) * 5;
		}
//		int hours =0;
		int minutes=0,seconds=0;;
	//	hours = Mathf.FloorToInt(totalTime/360.0f);
		minutes = Mathf.FloorToInt(totalTime/60.0f);
		seconds = Mathf.FloorToInt(totalTime%60.0f);
		string totalTime_String = string.Format("{0:00}m:{1:00}s",minutes,seconds);
		PlayerPrefs.SetString(PlayerPrefs.GetString("Mode")+"_"+"TotalTime",totalTime_String);
		GameOverScreen.SetActive(true);
		Game.SetActive(false);
		print("GameOver");
	}
	#endregion

	#region Set Infinity
	public void SetInfinity()
	{
		GetComponent<Text>().text = "8";
		GetComponent<Text>().fontSize = 40;
		Vector3 rot = transform.localEulerAngles;
		rot = new Vector3(rot.x,rot.y,90.0f);
		transform.localEulerAngles = rot;
	}
	#endregion
}
