using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uma_Game_Answer_Script : MonoBehaviour {
	#region data Declarations by Uma
	public bool Answer = false;
	#endregion

	#region Check Answer Function by Uma
	public void CheckAnswer () {
		ChangeColor();
		if(Answer)
			Camera.main.GetComponent<Uma_GameManager>().RightAnswer();
		else
			Camera.main.GetComponent<Uma_GameManager>().WrongAnswer();
	}
	#endregion

	#region Set Initial Color Function by Uma
	public void SetColor()
	{
		GetComponent<Image>().color = Color.white;
	}
	#endregion

	#region Change Color Function by Uma
	public void ChangeColor()
	{
		if(Answer)
			GetComponent<Image>().color = Color.green;
		else
			GetComponent<Image>().color = Color.red;
	}
	#endregion

}
