using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currentVelocity;
    public float MoveSpeed = 3f;
    public float SmoothRotationTime = 0.25f;
    public bool enableMobileInputs = false;
    public FixedButton Button;

    float CurrentSpeed;
    float speedVelocity;

    Transform cameraTransform;
    public FixedJoystick joystick;

    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = Vector2.zero;
        if (enableMobileInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        
        Vector2 inputDir = input.normalized;


        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg+ cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, SmoothRotationTime);
        }
        float targetSpeed = MoveSpeed * inputDir.magnitude;
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targetSpeed, ref speedVelocity, 0.12f);

      

        
        if (inputDir.magnitude > 0)
        {
            GetComponent<Actions>().Run();
        }
        else
        {
            GetComponent<Actions>().Stay();
        }



        transform.Translate(transform.forward * CurrentSpeed  * Time.deltaTime, Space.World);
    }
}
