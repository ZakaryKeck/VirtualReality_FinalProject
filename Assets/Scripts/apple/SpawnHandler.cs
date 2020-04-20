using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public int tester = 0;
    public int redNumber = 12;
    public int greenNumber = 12;
    public int rottenNumber = 6;
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
        for (int i = 0; i <= rottenNumber; i++)
        {
            spawnList.Add("rotten");
        }
        tester = spawnList.Count;
    }
}
