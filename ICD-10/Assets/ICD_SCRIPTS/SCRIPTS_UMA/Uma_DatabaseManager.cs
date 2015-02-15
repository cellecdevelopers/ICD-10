using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Uma_DatabaseManager : MonoBehaviour {
	#region declarations by Uma
	public TextAsset uma_Headings_Database;
	public TextAsset uma_SubHeadings_Database;
	public TextAsset uma_ElementHeadings_Database;
	public TextAsset[] uma_ElementsAZ_Database;
	List<string> uma_Headings_List = new List<string>();
	List<string>[] uma_ElementsHeading_List;
	List<string>[] uma_ElementAZ_List;
	List<string> subElementsHeadings;
	List<string> subElementsGroupHeadings;
	#endregion

	#region Start Function by Uma
	void Start ()
	{
		uma_ElementAZ_List = new List<string>[uma_ElementsAZ_Database.Length];
		uma_Headings_List = uma_Headings_Database.text.Split("\n"[0]).ToList();
		subElementsGroupHeadings = Regex.Split(uma_SubHeadings_Database.text,"\r\n%\r\n").ToList();
		subElementsHeadings = Regex.Split(uma_ElementHeadings_Database.text,"\r\n%\r\n").ToList();
		uma_ElementsHeading_List = new List<string>[subElementsHeadings.Count];
		for(int i = 0;i<subElementsHeadings.Count;i++)
		{
			uma_ElementsHeading_List[i] = Regex.Split(subElementsHeadings[i],"\r\n#\r\n").ToList();
        }
		for(int i = 0;i<uma_ElementsAZ_Database.Length;i++)
		{
			uma_ElementAZ_List[i] = Regex.Split(uma_ElementsAZ_Database[i].text,"\r\n#\r\n").ToList();
		}

		print(DatabaseGetHeadings(2));
		print(string.Join("\n",DatabaseGetGroupHeading(1,2).ToArray()));
		print(string.Join("\n",DatabaseGetElementHeadings(2).ToArray()));
	}
	#endregion

	#region GetElements Function by Uma
	List<string> DatabaseGetGroupHeading(int Group,int heading) 
	{
		return uma_ElementsHeading_List[Group][heading].Split("\n"[0]).ToList();
	}
	#endregion

	#region GetElementHeadings Function by Uma
	List<string> DatabaseGetElementHeadings(int Group) 
	{
		return subElementsHeadings[Group].Split("\n"[0]).ToList();
    }
    #endregion

	#region GetHeadings Function by Uma
	string DatabaseGetHeadings(int elementID) 
	{
		return uma_Headings_List[elementID];
    }
    #endregion
}
