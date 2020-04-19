using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class WaterLevelController : MonoBehaviour
{
    public GameObject target;
    public GameObject water;
    public Cap tubeCap;
    public bool full = false;

    private int waterLevel = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!tubeCap.isFull())
        {
            
            UnityEngine.Debug.Log("Collide Detect");
            Transform waterTrans = water.GetComponent<Transform>();
            waterTrans.position += new Vector3(0, .001f, 0);
        }
        else
        {
            this.full = true;
        }
    }
}

