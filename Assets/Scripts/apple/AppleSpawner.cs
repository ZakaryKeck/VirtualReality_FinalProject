using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public int tester = 0;
    public GameObject redApple;
    public GameObject greenApple;
    public GameObject rottenApple;
    public GameObject spawnerList;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5F);
        var appleList = spawnerList.GetComponent<SpawnHandler>().spawnList;
        if(appleList.Count > 0)
        {
            var removeLocation = Random.Range(0, appleList.Count - 1);
            string appleType = appleList[removeLocation];
            appleList.RemoveAt(removeLocation);
            spawnApple(appleType);
        }
    }

    public void spawnApple(string type)
    {
        tester = 1;
        if(type == "red")
        {
            var spawned = Instantiate(redApple);
            spawned.transform.position = transform.position;
            tester = 2;
        }
        else if (type == "green")
        {
            var spawned = Instantiate(greenApple);
            spawned.transform.position = transform.position;
            tester = 3;
        }
        else if (type == "rotten")
        {
            var spawned = Instantiate(rottenApple);
            spawned.transform.position = transform.position;
        }
    }
}