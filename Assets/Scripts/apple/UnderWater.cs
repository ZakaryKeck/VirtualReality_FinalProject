using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour
{
    private Color normalColor;
    private Color underwaterColor;
    public int tester;

    // Use this for initialization
    void Start()
    {
        tester = 0;
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    }

    void SetNormal()
    {
        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = 0.01f;
        RenderSettings.fog = false;

    }

    void SetUnderwater()
    {
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = 1f;
        RenderSettings.fog = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            tester = 1;
            SetUnderwater();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            tester = 0;
            SetNormal();
        }
    }
}
