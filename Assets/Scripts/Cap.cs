using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Cap : MonoBehaviour
{
    private bool full = false;
    
    private void OnTriggerEnter()
    {
        this.full = true;
    }

    private void OnTriggerExit()
    {
        this.full = false;
    }

    public bool isFull()
    {
        return this.full;
    }
}
