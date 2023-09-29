using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletToEnemy : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLV1") 
               ||  collision.gameObject.CompareTag("EnemyLV2") 
               ||  collision.gameObject.CompareTag("EnemyLV3")
               ||  collision.gameObject.CompareTag("EnemyLV4"))
        {
            GameObject hiteffect = Instantiate(hitEffect, transform.position, Quaternion.identity); // tao hieu ung efffect
            Destroy(hiteffect, 0.2f);
            Destroy(gameObject);
        }
    }
}
