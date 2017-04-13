using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class timer : MonoBehaviour
{
    public float g_time;
    public bool timmerOn;
    private imageSwapnScript m_img;
    // Use this for initialization
    void Start()
    {
        timmerOn = false;
        m_img = GameObject.FindGameObjectWithTag("GameController").GetComponent<imageSwapnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timmerOn)
        {
            g_time += Time.deltaTime;
        }
        if (g_time > 5)
        {
            saveTimmer();
            m_img.nextImage();
            timmerOn = false;
        }
    }

    public void startTimmer()
    {
        g_time = 0;
        timmerOn = true;
    }

    public void saveTimmer()
    {
        timmerOn = false;
        string temp = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        StreamWriter sw = new StreamWriter(temp + "/trail1.txt", true);
        if (g_time > 5)
        {
            sw.WriteLine(m_img.curImage + " Not Found");
        }
        else
        {
            sw.WriteLine(m_img.curImage + " " + g_time);
        }

        sw.Close();
    }

}


