﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeCheckPoint : MonoBehaviour
{
    public int CheckPointNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EmptyCone")
        {
            transform.parent.gameObject.GetComponent<ConeTrackerManager>().HitCheckpoint(CheckPointNumber);
        }
    }
}
