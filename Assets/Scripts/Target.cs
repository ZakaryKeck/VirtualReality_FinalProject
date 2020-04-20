using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool active = false;

    public void setActive(bool active)
    {
        this.active = active;
    }

    public bool getActive()
    {
        return this.active;
    }
}
