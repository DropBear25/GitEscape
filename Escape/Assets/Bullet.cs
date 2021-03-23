using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody m_rigidBody;
    float m_bulletSpeed = 8.0f;








    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
        if (m_rigidBody)
        {
            m_rigidBody.velocity = transform.up * m_bulletSpeed; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
