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


    const float MAX_COOLDOWN = 0.5f;
    float m_currentCooldown = 0.5f;

    int m_ammoCount = 20;

    void Start()
    {
        
    }

   
    void Update()
    {
        if(m_currentCooldown > 0.0f)
        {
            m_currentCooldown -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && m_currentCooldown <= 0.0f && m_ammoCount > 0)
        {
            if(m_bulletPrefab && m_bulletPrefab)
            {
                Instantiate(m_bulletPrefab, m_bulletSpawnPoint.position, m_bulletSpawnPoint.rotation * m_bulletPrefab.transform.rotation);

                m_currentCooldown = MAX_COOLDOWN;
                --m_ammoCount;

            }
        
        }
    }
}
