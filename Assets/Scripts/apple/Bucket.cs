using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public string type;
    public GameObject counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("redApple") && type == "red")
        {
            other.gameObject.SetActive(false);
            counter.GetComponent<counter>().redCount++;
        } else if(other.gameObject.CompareTag("greenApple") && type == "green")
        {
            other.gameObject.SetActive(false);
            counter.GetComponent<counter>().greenCount++;
        }
    }
}
