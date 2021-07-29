using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputController : MonoBehaviour
{
    public string inputSteerAxis = "Horizontal";
    public string inputThrottleAxis = "Vertical";

    public bool mobileInput;

    public float ThrottleInput { get; private set; }
    public float SteerInput { get; private set; }

    void Start()
    {
        
    }


    void Update()
    {
        if(!mobileInput)
        {
            SteerInput = Input.GetAxis(inputSteerAxis);
            ThrottleInput = Input.GetAxis(inputThrottleAxis);
        }
        else
        {
            SteerInput = CrossPlatformInputManager.GetAxis(inputSteerAxis);
            ThrottleInput = CrossPlatformInputManager.GetAxis(inputThrottleAxis);
        }
    }
}
