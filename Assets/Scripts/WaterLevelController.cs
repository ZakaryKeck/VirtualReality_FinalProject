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
    public Target target;
    public GameObject water;
    public Cap tubeCap;

    public GameObject Sparkles;
    public AudioSource CompleteSound;

    private int waterLevel = 1;
    private bool full = false;
    private bool playedSounds = false;

    void Update()
    {
        if (!tubeCap.isFull() && target.getActive())
        {
            Transform waterTrans = water.GetComponent<Transform>();
            waterTrans.position += new Vector3(0, .001f, 0);
        }
        if (tubeCap.isFull())
        {
            this.full = true;
            if (this.full && !this.playedSounds)
            {
                this.playedSounds = true;
                this.complete();
            }
            
        }
    }

    public bool IsFull()
    {
        return this.full;
    }

    private void complete()
    {
        GameObject sparkles = Instantiate(Sparkles, transform.position, transform.rotation);
        sparkles.transform.localScale = new Vector3(.05f, .05f, .05f);
        sparkles.GetComponent<ParticleSystem>().Play();
        Destroy(sparkles, 1);
        CompleteSound.Play();
    }

    public void reset()
    {
        this.full = false;
        this.playedSounds = false;
        // reset position of water tube
    }
}

