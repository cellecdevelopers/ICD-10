using UnityEngine;
using System.Collections;

public class Sri_PlayButton : MonoBehaviour {
	public GameObject nextActiveObject;
	public GameObject parentObject;
	public void PlayButtonClick()
	{
		this.gameObject.SetActive(true);
	}

	public void ScreenChange()
	{
		nextActiveObject.SetActive (true);
		parentObject.SetActive(false);
	}
}
