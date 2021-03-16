using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    FixedButton Button;

    [SerializeField]
        GameObject m_bulletPrefab;


    [SerializeField]
    Transform m_bulletSpawnPoint;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(m_bulletPrefab && m_bulletPrefab)
            {
                Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, m_bulletSpawnPoint.rotation * m_bulletPrefab.transform.rotation);
            }
        
        }
    }
}
