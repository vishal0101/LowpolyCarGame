using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum ControlType{ HumanInput, AI }
    public ControlType controlType = ControlType.HumanInput;

    public float BestLapTime { get; private set; } = Mathf.Infinity;
    public float LastLapTime { get; private set; } = 0;
    public float CurrentLapTime { get; private set; } = 0;
    public int CurrentLap { get; private set; } = 0;

    private float lapTimerTimestamp;
    private int lastCheckPointPassed = 0;

    private Transform checkpointsParent;
    private int checkpointCount;
    private int checkpointLayer;
    private CarNew carNew;

    void Awake()
    {
        checkpointsParent = GameObject.Find("CheckPoints").transform;
        checkpointCount = checkpointsParent.childCount;
        checkpointLayer = LayerMask.NameToLayer("Checkpoint");
        carNew = GetComponent<CarNew>();
    }

    void StartLap()
    {
        Debug.Log("StartLap!");
        CurrentLap++;
        lastCheckPointPassed = 1;
        lapTimerTimestamp = Time.time;
    }

    void EndLap()
    {
        LastLapTime = Time.time - lapTimerTimestamp;
        BestLapTime = Mathf.Min(LastLapTime, BestLapTime);
        Debug.Log("EndLap - LapTime was " + LastLapTime + "seconds");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != checkpointLayer)
        {
            return;
        }

        if(collider.gameObject.name == "1")
        {
            if(lastCheckPointPassed == checkpointCount)
            {
                EndLap();
            }

            if(CurrentLap == 0 || lastCheckPointPassed == checkpointCount)
            {
                StartLap();
            }
            return;
        }

        if(collider.gameObject.name == (lastCheckPointPassed + 1).ToString())
        {
            lastCheckPointPassed++;
        }

    }

    void Update()
    {
        CurrentLapTime = lapTimerTimestamp > 0 ? Time.time - lapTimerTimestamp : 0;

        if(controlType == ControlType.HumanInput)
        {
            carNew.Steer = GameManager.Instance.InputController.SteerInput;
            carNew.Throttle = GameManager.Instance.InputController.ThrottleInput;
        }
    }
}
