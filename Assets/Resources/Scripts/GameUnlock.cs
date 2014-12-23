using UnityEngine;
using System.Collections;
using System.IO;

public class GameUnlock {

    private bool m_bGameUnlock;

    public GameUnlock()
    {
        FileStream fs;

        string filepath = pathForDocumentsFile.path("game.dat");

        fs = new FileStream(filepath, FileMode.Open);
        if (fs == null)
        {
            fs = new FileStream(filepath, FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(false);
            sw.Close();
            fs.Close();

            fs = new FileStream(filepath, FileMode.Open);
        }
        StreamReader sr = new StreamReader(fs);

        m_bGameUnlock = bool.Parse(sr.ReadLine());

        sr.Close();
        fs.Close();
    }

    public bool BeGameUnlock()
    {
        return m_bGameUnlock;
    }

    public void DoGameUnlock()
    {
        if (!m_bGameUnlock)
        {
            FileStream fs = new FileStream(pathForDocumentsFile.path("game.dat"), FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            m_bGameUnlock = true;
            sw.WriteLine(m_bGameUnlock);

            sw.Close();
            fs.Close();
        }
    }
}
