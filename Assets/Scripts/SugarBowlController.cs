using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarBowlController : MonoBehaviour
{
    private Material fillColor1;
    private Material fillColor2;

    private bool filling = false;

    private GameObject sugar1 = null;
    private GameObject sugar2 = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sugar")
        {
            filling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sugar")
        {

            filling = false;
        }
    }

    private void OnTriggerStay()
    {

    }

    private void setSugar(GameObject Sugar)
    {
        if (this.sugar1 == null)
        {
            this.sugar1 = Sugar;
        }
        else if (this.sugar2 == null)
        {
            this.sugar2 = Sugar;
        }
    }
}
