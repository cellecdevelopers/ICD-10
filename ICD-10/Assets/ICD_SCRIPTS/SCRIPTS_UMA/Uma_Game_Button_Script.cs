using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uma_Game_Button_Script : MonoBehaviour {
	public GameObject uma_nextActiveObject;
	public GameObject uma_currentActiveObject;
	public void SwitchScreenFunction()
	{
		uma_nextActiveObject.SetActive(true);
		uma_currentActiveObject.SetActive(false);
	}

	public void Disable()
	{
		GetComponent<Button>().interactable = false;
	}
	public void RestartButtonFunction()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void MainMenuButtonFunction()
	{
		Application.LoadLevel("ICD_MENU");
	}
}
