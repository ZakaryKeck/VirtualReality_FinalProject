using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public string type;
    public GameObject counter;
    public Material done;
    public Material notDone;
    public Material Reddone;
    public Material RednotDone;
    // replaceing this with a proper list / parent object as soon as i can figure it out...
    public GameObject progress1;
    public GameObject progress2;
    public GameObject progress3;
    public GameObject progress4;
    public GameObject progress5;
    public GameObject progress6;
    public GameObject progress7;
    public GameObject progress8;
    public GameObject progress9;
    public GameObject progress10;
    public List<GameObject> progressList;

    public GameObject Redprogress1;
    public GameObject Redprogress2;
    public GameObject Redprogress3;
    public GameObject Redprogress4;
    public GameObject Redprogress5;
    public GameObject Redprogress6;
    public GameObject Redprogress7;
    public GameObject Redprogress8;
    public GameObject Redprogress9;
    public GameObject Redprogress10;
    public List<GameObject> RedprogressList;

    public int Test = 0;

    public AudioSource CompleteSound;
    public AudioSource FailedSound;
    public GameObject RedSparkles;
    public GameObject GreenSparkles;

    // Start is called before the first frame update
    void Start()
    {
        progressList.Add(progress1);
        progressList.Add(progress2);
        progressList.Add(progress3);
        progressList.Add(progress4);
        progressList.Add(progress5);
        progressList.Add(progress6);
        progressList.Add(progress7);
        progressList.Add(progress8);
        progressList.Add(progress9);
        progressList.Add(progress10);

        RedprogressList.Add(Redprogress1);
        RedprogressList.Add(Redprogress2);
        RedprogressList.Add(Redprogress3);
        RedprogressList.Add(Redprogress4);
        RedprogressList.Add(Redprogress5);
        RedprogressList.Add(Redprogress6);
        RedprogressList.Add(Redprogress7);
        RedprogressList.Add(Redprogress8);
        RedprogressList.Add(Redprogress9);
        RedprogressList.Add(Redprogress10);
    }

    // Update is called once per frame
    void UpdateProgress()
    {
        int g = counter.GetComponent<counter>().greenCount;
        int r = counter.GetComponent<counter>().redCount;
        Test = g;
        for(int i=0;i < g; i++){
            progressList[i].GetComponent<MeshRenderer>().material = done;
        }
        for(int i=g;i<progressList.Count;i++)
        {
            Test = i;
            progressList[i].GetComponent<MeshRenderer>().material = notDone;
        }

        for(int j=0;j < r; j++){
            RedprogressList[j].GetComponent<MeshRenderer>().material = Reddone;
        }
        for(int j=r;j<RedprogressList.Count-1;j++)
        {
            RedprogressList[j].GetComponent<MeshRenderer>().material = RednotDone;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("redApple") && type == "red")
        {
            //other.gameObject.SetActive(false);
            other.gameObject.tag = "Untagged";
            counter.GetComponent<counter>().redCount++;
            UpdateProgress();
            //Feedback
            GameObject sparkles = Instantiate(RedSparkles, transform.position, transform.rotation);
            sparkles.GetComponent<ParticleSystem>().Play();
            Destroy(sparkles, 1);
            CompleteSound.Play();
        } else if(other.gameObject.CompareTag("greenApple") && type == "green")
        {
            //other.gameObject.SetActive(false);
            other.gameObject.tag = "Untagged";
            counter.GetComponent<counter>().greenCount++;
            UpdateProgress();

            //Feedback
            GameObject sparkles = Instantiate(GreenSparkles, transform.position, transform.rotation);
            sparkles.GetComponent<ParticleSystem>().Play();
            Destroy(sparkles, 1);
            CompleteSound.Play();
        } else if(other.gameObject.CompareTag("rottenApple"))
        {
            //other.gameObject.SetActive(false);
            other.gameObject.tag = "Untagged";
            if(counter.GetComponent<counter>().greenCount > 0)
            {
                counter.GetComponent<counter>().greenCount--;
            }
            if(counter.GetComponent<counter>().redCount > 0)
            {
                counter.GetComponent<counter>().redCount--;
            }
            UpdateProgress();
            FailedSound.Play();
        }
    }
}
