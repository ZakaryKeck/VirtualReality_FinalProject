using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public int tester = 0;
    public int redNumber = 5;
    public int greenNumber = 5;
    public int yellowNumber = 0;
    public List<string> spawnList;
    // Start is called before the first frame update
    void Start()
    {
        spawnList = new List<string>();
        for(int i = 0; i <= redNumber; i++)
        {
            spawnList.Add("red");
        }
        for (int i = 0; i <= greenNumber; i++)
        {
            spawnList.Add("green");
        }
        for (int i = 0; i <= yellowNumber; i++)
        {
            spawnList.Add("yellow");
        }
        tester = spawnList.Count;
    }
}
