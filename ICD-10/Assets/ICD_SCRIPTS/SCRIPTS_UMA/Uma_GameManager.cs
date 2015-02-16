using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Uma_GameManager : MonoBehaviour {

	#region dataVariables by Uma
	public Text uma_QuestionText;
	public Text[] uma_AnswerTexts;
	public Text  uma_questionNumber;
	public Text  uma_ScoreNumber;
	public float incrementTime;
	public float decrementTime;
	public float colorWaitTime;
	public Uma_GameTime gameTime;
	#endregion

	#region Start Function by Uma
	void Start () {
		SetQuestion();
	}
	#endregion

	#region Time Increment Function by Uma
	void TimeIncrement()
	{
		if(incrementTime>2.0f)
			incrementTime = incrementTime + (int.Parse(uma_questionNumber.text)/10)*1.0f;
			gameTime.startTime = gameTime.startTime+ incrementTime;
	}
	#endregion

	#region Time Decrement Function by Uma
	void TimeDecrement()
	{
		if(decrementTime<10.0f)
			decrementTime = decrementTime + (int.Parse(uma_questionNumber.text)/10)*1.0f;
		gameTime.startTime =  gameTime.startTime- decrementTime;
	}
	#endregion

	#region 	SetQuestion Function by Uma
	void SetQuestion () {
		uma_questionNumber.text = (int.Parse(uma_questionNumber.text)+1).ToString();
	}
	#endregion

	#region SetAnswer Function by Uma
	void SetAnswer(string Answer)
	{
		int rand = UnityEngine.Random.Range(0,4);
		for(int i = 0;i<uma_AnswerTexts.Length;i++)
		{
			uma_AnswerTexts[i].transform.parent.gameObject.SetActive(true);
			uma_AnswerTexts[i].transform.parent.GetComponent<Uma_Game_Answer_Script>().SetColor();
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

	#region HintPowerUp Function by Uma
	public void HintPowerUp()
	{

	}
	#endregion

	#region FiftyPowerUp Function by Uma
	public void FiftyPowerUp()
	{
		int i = 0;

		do
		{
			int rand = GetRandomText();
			print(i.ToString()+" Random- "+rand.ToString());
			if(fiftyFunction(uma_AnswerTexts[rand].transform.parent.GetComponent<Uma_Game_Answer_Script>()))
			{
			
				i++;
			}
		}
		while(i<2);
	}
	#endregion

	int GetRandomText()
	{
		int rand = Random.Range(0,uma_AnswerTexts.Length);
		return rand;
	}

	#region fiftyCheckFunction
	bool fiftyFunction(Uma_Game_Answer_Script wrongAnswer)
	{
		if(!wrongAnswer.Answer&&wrongAnswer.gameObject.activeSelf==true)
		{
			wrongAnswer.gameObject.SetActive(false);
			return true;
		}
		else 
		{
			return false;
		}
	}
	#endregion

	#region SkipPowerUp Function by Uma
	public void SkipPowerUp()
	{
		SetQuestion();
	}
	#endregion

	#region RightAnswer Function by Uma
	public void RightAnswer()
	{
		uma_ScoreNumber.text = (int.Parse(uma_ScoreNumber.text)+100).ToString();
		TimeIncrement();
		Invoke("ColorWaitFunction",colorWaitTime);
	}
	#endregion

	#region WrongAnswer Function by Uma
	public void WrongAnswer()
	{
		TimeDecrement();
		for(int i = 0;i <uma_AnswerTexts.Length;i++)
		{
			if(uma_AnswerTexts[i].transform.parent.GetComponent<Uma_Game_Answer_Script>().Answer)
				uma_AnswerTexts[i].transform.parent.GetComponent<Uma_Game_Answer_Script>().ChangeColor();
		}
		Invoke("ColorWaitFunction",colorWaitTime);
	}
	#endregion

	#region Color Wait Function by Uma
	void ColorWaitFunction()
	{
		SetQuestion();
		SetAnswer("Hello");
	}
	#endregion

}
