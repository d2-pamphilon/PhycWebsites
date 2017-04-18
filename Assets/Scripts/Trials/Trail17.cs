using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public class Trail17 : MonoBehaviour {


    public float g_time;
    public bool timmerOn;
    public bool b_cross;

    public Sprite Cross;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;
    public Sprite image7;
    public Sprite image8;
    public Sprite image9;
    public Sprite image10;

    public string curImage;
    public int imageCount = 1;

    private Sprite curObj;
    [SerializeField]
    private List<int> imgsUsed;


    void Start()
    {
        timmerOn = false;
        b_cross = true;
        nextImage();
    }


    void Update()
    {

        if (timmerOn)
        {
            g_time += Time.deltaTime;
        }

        if (g_time > 5)
        {
            if (!b_cross)
            {
                saveTimmer();
                b_cross = true;
            }
            else
            {
                b_cross = false;
            }

            nextImage();
            //timmerOn = false;
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
        //  b_cross = true;
        string temp = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        StreamWriter sw = new StreamWriter(temp + "/Yellow & Blue 7.txt", true);
        if (g_time > 5)
        {
            sw.WriteLine(curImage + " Not Found");
        }
        else
        {
            sw.WriteLine(curImage + " " + g_time);
        }

        sw.Close();
    }

    private void spawnImage()
    {
        // Destroy(curObj);

        switch (imageCount)
        {
            case 1:
                curObj = image1;
                curImage = image1.name;
                break;
            case 2:
                curObj = image2;
                curImage = image2.name;
                break;
            case 3:
                curObj = image3;
                curImage = image3.name;
                break;
            case 4:
                curObj = image4;
                curImage = image4.name;
                break;
            case 5:
                curObj = image5;
                curImage = image5.name;
                break;
            case 6:
                curObj = image6;
                curImage = image6.name;
                break;
            case 7:
                curObj = image7;
                curImage = image7.name;
                break;
            case 8:
                curObj = image8;
                curImage = image8.name;
                break;
            case 9:
                curObj = image9;
                curImage = image9.name;
                break;
            case 10:
                curObj = image10;
                curImage = image10.name;
                break;
            case 11:
                curObj = Cross;

                break;
            default:
                Debug.Log("outside values");
                break;
        }
        this.GetComponent<SpriteRenderer>().sprite = curObj;
        // Instantiate(curObj, transform.position, transform.rotation);
        startTimmer();

    }

    public void nextImage()
    {
        if (!b_cross)
        {
            if (imgsUsed.Count >= 10)
            {
                SceneManager.LoadScene("Trail18");
            }

            bool exit;
            int t_img;
            do
            {
                exit = true;
                t_img = Random.Range(1, 10);
                foreach (int i in imgsUsed)
                {
                    if (i == t_img)//if been used
                    {
                        exit = false;
                    }

                }

            } while (exit == false);

            imgsUsed.Add(t_img);
            imageCount = t_img;
            spawnImage();

        }
        else
        {
            imageCount = 11;
            spawnImage();
        }

    }

    public void flipcross()
    {
        b_cross = true;
    }
}
