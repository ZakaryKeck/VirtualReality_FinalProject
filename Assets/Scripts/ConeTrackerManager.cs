using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTrackerManager : MonoBehaviour
{
    private GameObject CurrentCone;
    private RotationChecker RotationChecker = new RotationChecker();
    private float maxCottonCandySize = .8f;
    public GameObject Sparkles;

    public void HitCheckpoint(int index)
    {
        RotationChecker.AddCheckpoint(index);
        if (RotationChecker.CheckComplete())
        {
            if (CurrentCone.transform.GetChild(0).gameObject.transform.localScale[0] < maxCottonCandySize)
            {
                //Increase Cone Size
                CurrentCone.transform.GetChild(0).gameObject.transform.localScale += new Vector3(.2f, .2f, .2f);
                Instantiate(Sparkles, CurrentCone.transform.GetChild(0).gameObject.transform);
            } else
            {
                //Instantiate sparkles feedback
                Debug.Log('k');
                Instantiate(Sparkles, CurrentCone.transform.GetChild(0).gameObject.transform);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EmptyCone")
        {
            CurrentCone = other.gameObject;
        }
    }

}

public class RotationChecker
{
    //Int array to track which checkpoints have been hit
    private int[] CheckPointStatuses = { 0, 0, 0, 0 };
    //Int to track which checkpoint was entered first
    private int FirstCheckpoint = -1;
    //Int to track the last hit checkpoint
    private int CurrentCheckpoint;
    //Enum to track direction of rotation, "Clockwise" or "Counterclockwise"
    private Directions Direction = Directions.None;
    //Float stating what percent of checkpoints need to be hit per rotation
    private float SuccessThreshold = 1f;

    public bool CheckComplete()
    {
        var numCheckPointsTouched = 0f;
        for(int i = 0; i < CheckPointStatuses.Length; i++)
        {
            numCheckPointsTouched += CheckPointStatuses[i];
        }
        bool success = (numCheckPointsTouched / CheckPointStatuses.Length >= SuccessThreshold);

        if (success)
        {
            FirstCheckpoint = -1;
            CurrentCheckpoint = -1;
            Direction = Directions.None;
            Array.Clear(CheckPointStatuses, 0, CheckPointStatuses.Length);
        }

        return success; 
    }

    public void AddCheckpoint(int index)
    {
        //If entering for the first time
        if (FirstCheckpoint == -1)
        {
            FirstCheckpoint = index;
            CurrentCheckpoint = index;
            CheckPointStatuses[index] = 1;
        }
        else if(index == CurrentCheckpoint + 1 || (CurrentCheckpoint == 3 && index == 0))
        {
            if(Direction == Directions.None)
            {
                Direction = Directions.Clockwise;
                CurrentCheckpoint = index;
                CheckPointStatuses[index] = 1;
            } 
            else if(Direction == Directions.Clockwise)
            {
                CheckPointStatuses[index] = 1;
                CurrentCheckpoint = index;
            } 
            else if(Direction == Directions.Counterclockwise)
            {
                //Do Nothing?
                //Or Reset?
            }
        } 
        else if(index == CurrentCheckpoint - 1 || (CurrentCheckpoint == 0 && index == 3))
        {
            if(Direction == Directions.None)
            {
                Direction = Directions.Counterclockwise;
                CurrentCheckpoint = index;
                CheckPointStatuses[index] = 1;
            }
            else if(Direction == Directions.Counterclockwise)
            {
                CheckPointStatuses[index] = 1;
                CurrentCheckpoint = index;
            }
            else if (Direction == Directions.Clockwise)
            {
                //Do Nothing?
                //Or Reset?
            }
        }
    }
}

enum Directions
{
    Clockwise,
    Counterclockwise,
    None
}