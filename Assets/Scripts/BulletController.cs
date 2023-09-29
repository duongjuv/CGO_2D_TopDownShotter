using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        // Lấy hướng trục local (trục tương đối) của GameObject
        Vector3 localDirection = new Vector3(1.0f, 0.0f, 0.0f);

        // Di chuyển theo hướng local với tốc độ cố định
        transform.Translate(localDirection * moveSpeed * Time.deltaTime);
    }
}
