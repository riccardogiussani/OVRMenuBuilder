using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] GameObject target;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = target.transform.rotation;
    }
}
