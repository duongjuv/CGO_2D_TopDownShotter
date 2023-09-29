using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMouse : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mosPos = (Input.mousePosition);
        transform.position = mosPos;
    }
}
