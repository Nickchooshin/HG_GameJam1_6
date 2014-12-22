using UnityEngine;
using System.Collections;
using System.IO;

public class QuizLoad {
	
	private string m_strQuestion;
	private string[] m_strAnswer;
	private int m_nAnswer;
	
	public QuizLoad(string strFilePath)
	{
		strFilePath = Application.dataPath + "/" + strFilePath;
		
		FileStream fs = new FileStream(strFilePath, FileMode.Open);
		StreamReader sr = new StreamReader(fs);
		
		m_strAnswer = new string[3];
		
		m_strQuestion = sr.ReadLine();
		for (int i = 0; i < 3; i++)
			m_strAnswer[i] = sr.ReadLine();
		m_nAnswer = int.Parse(sr.ReadLine());

        sr.Close();
	}
	
	public string GetQuestion()
	{
		return m_strQuestion;
	}
	
	public string GetAnswer(int num)
	{
		return m_strAnswer[num];
	}
	
	public int GetAnswerNum()
	{
		return m_nAnswer;
	}
}

