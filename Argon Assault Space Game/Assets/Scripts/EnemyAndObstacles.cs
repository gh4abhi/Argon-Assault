using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndObstacles : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject EnemyDeathFX;
    [SerializeField] Transform parent;
    
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
        GameObject fx = Instantiate(EnemyDeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject); 
    }
}
