using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class cccontroller : MonoBehaviour
{
    public GameObject blue;
    public GameObject green;
    public GameObject pink;
    
    public SugarController blueSugar;
    public SugarController greenSugar;
    public SugarController pinkSugar;

    public GameObject blueDisk;
    public GameObject greenDisk;
    public GameObject pinkDisk;

    public Material blueMat;
    public Material greenMat;
    public Material pinkMat;

    public GameObject cottonCandy;

    public string currentColor = "blue";

    private Material diskMat = null;

    // Start is called before the first frame update
    void Start()
    {
        randomizeColor();
    }

    void OnTriggerEnter(Collider collider)
    {
        Console.WriteLine(collider.tag);
        if (collider.tag == this.currentColor)
        {
            if (collider.tag == "blue" &&  this.blueSugar.IsPouring()) {
                enableDisk();
            }
            if (collider.tag == "green" && this.greenSugar.IsPouring())
            {
                enableDisk();
            }
            if (collider.tag == "pink" && this.pinkSugar.IsPouring())
            {
                enableDisk();
            }
        }
    }

    void enableDisk()
    {
        if (currentColor == "blue")
        {
            this.blueDisk.SetActive(true);
            this.greenDisk.SetActive(false);
            this.pinkDisk.SetActive(false);
        }
        if (currentColor == "green")
        {
            this.blueDisk.SetActive(false);
            this.greenDisk.SetActive(true);
            this.pinkDisk.SetActive(false);
        }
        if (currentColor == "pink")
        {
            this.blueDisk.SetActive(false);
            this.greenDisk.SetActive(false);
            this.pinkDisk.SetActive(true);
        }
    }

    void randomizeColor()
    {
        string[] colorList = {"blue", "green", "pink"};
        System.Random random = new System.Random();
        int r = random.Next(0, 3);
        this.currentColor = colorList[r];

        if (r == 0)
        {
            this.blue.SetActive(true);
            this.green.SetActive(false);
            this.pink.SetActive(false);
            this.cottonCandy.GetComponent<MeshRenderer>().material = this.blueMat;
        } if (r == 1)
        {
            this.blue.SetActive(false);
            this.green.SetActive(true);
            this.pink.SetActive(false);
            this.cottonCandy.GetComponent<MeshRenderer>().material = this.greenMat;
        } if (r == 2)
        {
            this.blue.SetActive(false);
            this.green.SetActive(false);
            this.pink.SetActive(true);
            this.cottonCandy.GetComponent<MeshRenderer>().material = this.pinkMat;
        }
    }
}
