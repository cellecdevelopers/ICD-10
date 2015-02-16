using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uma_GameTime : MonoBehaviour {

	#region Data Declarations
	public GameObject GameOverScreen;
	public GameObject Game;
	public TextMesh timeText;
	public bool Doit =false;
	float time;
	public float timeSpeed;
	public float startTime;
	#endregion

	#region StartFunction
	void Start()
	{
		time = 0;
	}
	#endregion

	#region UpdateFunction
	void FixedUpdate()
	{
		float diff = startTime - time;
		int diffText = Mathf.FloorToInt(diff);
		if(Doit&&diff > -1&&Time.timeScale == 1.0f&&renderer.sharedMaterial.mainTextureOffset.x <1.01f)
		{
			time = time + timeSpeed;
			if(diffText>=0)
			timeText.text = diffText.ToString();
			renderer.sharedMaterial.mainTextureOffset = new Vector2(1-(diff/startTime),0);
			if(diff < 0)
			{
				Doit = false;
				//CloseThis();
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
			totalTime = totalTime + startTime - (PlayerPrefs.GetInt(PlayerPrefs.GetString("Mode")+"_"+"LevelNumber")-1) * 5;
		}
		//	int hours =0;
		int minutes=0,seconds=0;;
		//	hours = Mathf.FloorToInt(totalTime/360.0f);
		minutes = Mathf.FloorToInt(totalTime/60.0f);
		seconds = Mathf.FloorToInt(totalTime%60.0f);
		string totalTime_String = string.Format("{0:00}m:{1:00}s",minutes,seconds);
		PlayerPrefs.SetString(PlayerPrefs.GetString("Mode")+"_"+"TotalTime",totalTime_String);
		GameOverScreen.SetActive(true);
		Game.SetActive(false);
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
