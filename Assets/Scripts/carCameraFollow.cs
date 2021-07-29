using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carCameraFollow : MonoBehaviour
{
    public GameObject Target;
    public GameObject LookAtTarget;

    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, LookAtTarget.transform.position, Time.deltaTime * speed);
        transform.LookAt(Target.transform.position);
    }
}
