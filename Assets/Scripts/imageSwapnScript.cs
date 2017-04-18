using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageSwapnScript : MonoBehaviour
{
    //add more then do in order
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    public GameObject image9;
    public GameObject image10;

    public string curImage;
    public int imageCount=1;
    private List<int> usedImg;

    private GameObject curObj;
    void Update()
    {
       
    }

    private void spawnImage()
    {
        switch (imageCount)
        {
            case 1:
                curObj = image1;
                break;
            case 2:
                curObj = image2;
                break;
            case 3:
                curObj = image3;
                break;
            case 4:
                curObj = image4;
                break;
            case 5:
                curObj = image5;
                break;
            case 6:
                curObj = image6;
                break;
            case 7:
                curObj = image7;
                break;
            case 8:
                curObj = image8;
                break;
            case 9:
                curObj = image9;
                break;
            case 10:
                curObj = image10;
                break;
            default:
                Debug.Log("outside values");
                break;             
        }
        Instantiate(curObj, transform.position, transform.rotation);
        curImage = image1.name;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<timer>().startTimmer();
    }

    public void nextImage()
    {
        bool exit = false;
        int tempRnd;
        do {
            tempRnd = Random.Range(1, 10);
            foreach (int i in usedImg)
            {
                if (tempRnd == i)
                {
                    exit = true;
                }
            }

        }
        while (exit == false);
        imageCount = tempRnd;
        spawnImage();
    }



}
