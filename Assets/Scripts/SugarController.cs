using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarController : MonoBehaviour
{
    public Material pouringTexture;
    public Material defaultMaterial;
    public int pourThreshold;
    public Transform origin = null;
    public GameObject streamPrefab = null;

    private bool isPouring = false;
    private Stream currentStream = null;
    
    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;
        
        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        gameObject.GetComponent<MeshRenderer>().material = pouringTexture;
        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {
        gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;
        currentStream.End();
        currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);
        return streamObject.GetComponent<Stream>();
    }
}
