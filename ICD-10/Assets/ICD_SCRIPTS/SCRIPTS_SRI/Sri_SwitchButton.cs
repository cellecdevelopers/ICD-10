using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sri_SwitchButton : MonoBehaviour {
	public Sprite onSprite;
	public Sprite offSprite;
	bool switchValue=true;

	public void SpriteChange()
	{
		if (switchValue) {
			switchValue = false;
			GetComponent<Image> ().sprite = offSprite;
		} 
		else
		{
			switchValue = true;
			GetComponent<Image> ().sprite = onSprite;
		}
	}
}
