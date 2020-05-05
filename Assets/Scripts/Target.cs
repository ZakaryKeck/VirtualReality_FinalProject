using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool active = false;

    public float speed = 0.025f;

    private double yMax = 0.8f;
    private double yMin = 0.3f;

    public int direction = 1;

    public void setActive(bool active)
    {
        this.active = active;
    }

    public bool getActive()
    {
        return this.active;
    }

    /*void Update()
    {   
        
        double yNew = transform.position.y + direction * speed * Time.deltaTime;
        Debug.Log(yNew);
        if (yNew >= yMax)
        {
            yNew = yMax;
            direction *= -1;
        }
        else if (yNew <= yMin)
        {
            yNew = yMin;
            direction *= -1;
        }

        transform.position = new Vector3(transform.position.x, (float)yNew, transform.position.z);
        
    }*/
}
