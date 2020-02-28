using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleFloat : MonoBehaviour
{
    public float speed = 0.025f;

    public float tester;

    private float xRotate;
    private float yRotate;
    private float zRotate;

    private double yMax;
    private double yMin;

    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.025f;
        tester = Random.Range(0f, 1f);

        float randomDirection = tester;
        //float randomDirection = Random.Range(0f, 1f);
        if (randomDirection <= 0.5f)
        {
            direction = -1;
        }

        xRotate = Random.Range(0f, 359f);
        yRotate = Random.Range(0f, 359f);
        zRotate = Random.Range(0f, 359f);

        yMax = transform.position.y + 0.025;
        yMin = transform.position.y - 0.025;

        transform.Rotate(new Vector3(xRotate, yRotate, zRotate));
    }

    // Update is called once per frame
    void Update()
    {

        double yNew = transform.position.y + direction * speed * Time.deltaTime;
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
        transform.Rotate(new Vector3(15, 15, 15) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("water"))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
