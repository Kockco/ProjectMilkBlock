using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextSaveLoad : MonoBehaviour
{
    void Start()
    {

    }

    // Use this for initialization
    string m_strPath = "Assets/Resources/";

    public void WriteData(string strData)
    {
        FileStream f = new FileStream(m_strPath + "MapData.txt", FileMode.CreateNew, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.Write(strData + " ");
        writer.Close();
    }
    public void LineJump()
    {
        FileStream f = new FileStream(m_strPath + "MapData.txt", FileMode.CreateNew, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.WriteLine();
        writer.Close();
    }

    public void Parse()
    {
        TextAsset data = Resources.Load("MapData.txt", typeof(TextAsset)) as TextAsset;
        StringReader sr = new StringReader(data.text);
        // 먼저 한줄을 읽는다. 
        string source = sr.ReadLine();
        string value = "";
        while (source != null)
        {
            if (source == null)
            {
                sr.Close();
                return;
            }
            value += source + "\n";
            source = sr.ReadLine();    // 한줄 읽는다.
        }
        Debug.Log(value);
    }
    void Update()
    {
        
    }
}
