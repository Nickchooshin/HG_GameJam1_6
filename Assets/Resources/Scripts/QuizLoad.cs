using UnityEngine;
using System.Collections;
using System.IO;

public class QuizLoad {
	
	private string m_strQuestion;
	private string[] m_strAnswer;
	private int m_nAnswer;
	
	public QuizLoad(string strFilePath)
	{
        TextAsset textAsset = Resources.Load(strFilePath) as TextAsset;
        TextReader reader = new StringReader(textAsset.text);
		
		m_strAnswer = new string[3];

        m_strQuestion = reader.ReadLine();
		for (int i = 0; i < 3; i++)
            m_strAnswer[i] = reader.ReadLine();
        m_nAnswer = int.Parse(reader.ReadLine());

        reader.Close();
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

