using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEffectWithPlayer : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectToPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerVip"))
        {
            GameObject hiteffect = Instantiate(hitEffectToPlayer, transform.position, Quaternion.identity); // tao hieu ung efffect
            Destroy(hiteffect, 0.3f);
            Destroy(gameObject);
        }
    }

}
