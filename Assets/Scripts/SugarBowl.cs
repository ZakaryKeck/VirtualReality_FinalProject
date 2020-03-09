using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarBowl : MonoBehaviour
{
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;

    public int fillTime;
    private int filled = 0;
    private bool filling = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(filled + ">" + fillTime);
        if (filled >= fillTime)
        {
            stage3.SetActive(true);
        } 
        if (filled >= fillTime / 3)
        {
            stage1.SetActive(true);
        }
        if (filled >= fillTime * 2/3)
        {
            stage2.SetActive(true);
        }
    }

    public void fill()
    {
        Debug.Log("filled + 1" + this.filled);
        filled++;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.tag == "sugar_stream")
        {
            filling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "sugar_stream")
        {
            filling = false;
        }
    }

    private void OnTriggerStay()
    {
        if (filling)
        {
            filled += 1;
        }
    }
}
