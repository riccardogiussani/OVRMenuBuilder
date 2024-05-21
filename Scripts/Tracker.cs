using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    [Range(0, 10)] public float kI;

    [SerializeField] GameObject positionTracker;
    [SerializeField] GameObject rotationTracker;

    void FixedUpdate()
    {
        if (positionTracker != null)
            SetPosition();

        if (rotationTracker != null)
            SetRotation();
    }

    private void SetRotation()
    {
        transform.rotation = rotationTracker.transform.rotation;
    }

    private void SetPosition()
    {
        Vector3 reference = positionTracker.transform.position;

        Vector3 actual = transform.position;

        Vector3 error = reference - actual;

        //Vector3 control = kP * error + kI * error * Time.deltaTime; // + kD * error/Time.deltaTime;

        Vector3 control = kI * error * Time.fixedDeltaTime;

        transform.position += control;
    }
}
