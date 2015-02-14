using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Uma_DatabaseManager : MonoBehaviour {
	#region declarations by Uma
	public TextAsset uma_Headings_Database;
	public TextAsset uma_SubHeadings_Database;
	public TextAsset[] uma_ElementsAZ_Database;
	public List<string> uma_Headings_List = new List<string>();
	public List<string> uma_SubHeadings_List = new List<string>();
	public List<string>[] uma_SubHeadingElements_List;
	public List<string>[] uma_ElementAZ_List;
	#endregion

	#region Start Function by Uma
	void Start ()
	{
		uma_ElementAZ_List = new List<string>[uma_ElementsAZ_Database.Length];
		uma_Headings_List = uma_Headings_Database.text.Split("\n"[0]).ToList();
		int count = 0;
		string input = uma_SubHeadings_Database.text;
		for (int j = 0; j < input.Length; j++)
		{
			if ('%' == input[j])
			{
				count++;
			}
		}
		print(count.ToString());
		uma_SubHeadingElements_List = new List<string>[count+1];
		List<string> subElements = Regex.Split(uma_SubHeadings_Database.text,"\r\n%\r\n").ToList();
		//List<string> subElements = uma_SubHeadings_Database.text.Split("%"[0]).ToList();
		print(subElements.Count.ToString());
        for(int i = 0;i<subElements.Count;i++)
		{
			uma_SubHeadingElements_List[i] = Regex.Split(subElements[i],"\r\n#\r\n").ToList();
        }
		for(int i = 0;i<uma_ElementsAZ_Database.Length;i++)
		{
			uma_ElementAZ_List[i] = Regex.Split(uma_ElementsAZ_Database[i].text,"\r\n#\r\n").ToList();
		}

		print(string.Join("\n====\n",uma_SubHeadingElements_List[0].ToArray()));
		print (uma_SubHeadingElements_List[0][2].Split("\n"[0])[3]);
	}
	#endregion

	#region _____ Function by Uma
	void DatabaseGet () 
	{
	
	}
	#endregion
}
