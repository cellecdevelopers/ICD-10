using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uma_GameManager : MonoBehaviour {
	#region dataVariables by Uma
	public Text uma_QuestionText;
	public Text[] uma_AnswerTexts;
	#endregion

	#region Start Function by Uma
	void Start () {
	
	}
	#endregion
	
	#region 	SetQuestion Function by Uma
	void SetQuestion () {

	}
	#endregion

	#region SetAnswer Function by Uma
	void SetAnswer(string Answer)
	{
		int rand = UnityEngine.Random.Range(0,4);
		for(int i = 0;i<uma_AnswerTexts.Length;i++)
		{
			if(i == rand)
			{
				uma_AnswerTexts[i].text = Answer;
				uma_AnswerTexts[i].transform.parent.GetComponent<Uma_Game_Answer_Script>().Answer = true;
			}
			else
			{
				uma_AnswerTexts[i].text = GetRandomAnswers(Answer);
				uma_AnswerTexts[i].transform.parent.GetComponent<Uma_Game_Answer_Script>().Answer = false;
			}
		}

	}
	#endregion

	#region GetRandomAnswers Function by Uma
	string GetRandomAnswers(string Answer)
	{
		string randomAnswer = "";
		return randomAnswer;
	}
	#endregion

}
