using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public string type;
    public GameObject counter;
    public Material done;
    public Material notDone;
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
    }

    // Update is called once per frame
    void UpdateProgress()
    {
        int j = counter.GetComponent<counter>().redCount + counter.GetComponent<counter>().greenCount;
        Test = j;
        for(int i=0;i < j; i++){
            progressList[i].GetComponent<MeshRenderer>().material = done;
        }
        for(int i=j;i<progressList.Count;i++)
        {
            progressList[i].GetComponent<MeshRenderer>().material = notDone;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("redApple") && type == "red")
        {
            other.gameObject.SetActive(false);
            counter.GetComponent<counter>().redCount++;
            UpdateProgress();
            //Feedback
            GameObject sparkles = Instantiate(RedSparkles, transform.position, transform.rotation);
            sparkles.GetComponent<ParticleSystem>().Play();
            Destroy(sparkles, 1);
            CompleteSound.Play();
        } else if(other.gameObject.CompareTag("greenApple") && type == "green")
        {
            other.gameObject.SetActive(false);
            counter.GetComponent<counter>().greenCount++;
            UpdateProgress();

            //Feedback
            GameObject sparkles = Instantiate(GreenSparkles, transform.position, transform.rotation);
            sparkles.GetComponent<ParticleSystem>().Play();
            Destroy(sparkles, 1);
            CompleteSound.Play();
        } else if(other.gameObject.CompareTag("rottenApple"))
        {
            other.gameObject.SetActive(false);
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
