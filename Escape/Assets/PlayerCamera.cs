using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float Yaxis;
    public float Xaxis;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Yaxis = Input.GetAxis("Mouse X");

        print(Yaxis); 





    }
}
