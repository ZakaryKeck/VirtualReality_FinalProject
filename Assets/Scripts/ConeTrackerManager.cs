using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeTrackerManager : MonoBehaviour
{
    private GameObject CurrentCone;
    private RotationChecker RotationChecker = new RotationChecker();

    public void HitCheckpoint(int index)
    {
        RotationChecker.AddCheckpoint(index);
        if (RotationChecker.CheckComplete())
        {
            //Increase Cone Size
            CurrentCone.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Check tag?
        CurrentCone = other.gameObject;
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
    private float SuccessThreshold = 0.75f;

    public bool CheckComplete()
    {
        var numCheckPointsTouched = 0;
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
        if(FirstCheckpoint == -1)
        {
            FirstCheckpoint = index;
            CurrentCheckpoint = index;
        }
        else if(index == CurrentCheckpoint + 1)
        {
            if(Direction == Directions.None)
            {
                Direction = Directions.Clockwise;
            } 
            else if(Direction == Directions.Clockwise)
            {
                CheckPointStatuses[index] = 1;
                CurrentCheckpoint = index;
            } 
            else if(Direction == Directions.Counterclockwise)
            {
                //Do Nothing?
            }
        } 
        else if(index == FirstCheckpoint - 1)
        {
            if(Direction == Directions.None)
            {
                Direction = Directions.Counterclockwise;
            }
            else if(Direction == Directions.Clockwise)
            {
                //Do Nothing?
            }
            else if(Direction == Directions.Counterclockwise)
            {
                CheckPointStatuses[index] = 1;
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