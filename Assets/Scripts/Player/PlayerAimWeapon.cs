using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;   // vi tri cua con tro chuot
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
