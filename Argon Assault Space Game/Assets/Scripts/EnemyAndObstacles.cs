using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndObstacles : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject EnemyDeathFX;
    
    void Start()
    {
        AddNonTriggerBoxCollider();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        Instantiate(EnemyDeathFX, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }
}
