using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currentVelocity;
    public float MoveSpeed = 3f;
    public float SmoothRotationTime = 0.25f;
     

    float CurrentSpeed;
    float speedVelocity;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;


        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, SmoothRotationTime);
        }
        float targetSpeed = MoveSpeed * inputDir.magnitude;
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targetSpeed, ref speedVelocity, 0.1f);

        transform.Translate(transform.forward * CurrentSpeed  * Time.deltaTime, Space.World);
    }
}
