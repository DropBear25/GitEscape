using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 8f;

    float RotationMin = -40f;
    float RotationMax = 80f;
    float smoothTime = 0.9f;
    Vector3 targetRotation;
    Vector3 currentVel;

    public Transform target;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Yaxis += Input.GetAxis("Mouse X")* RotationSensitivity;
        Xaxis -= Input.GetAxis("Mouse Y")* RotationSensitivity;


      Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);
        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
       transform.eulerAngles = targetRotation;

       transform.position = target.position - transform.forward * 2f;

        





    }
}
