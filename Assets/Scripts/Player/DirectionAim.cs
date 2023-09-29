using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionAim : MonoBehaviour
{
    private Transform aimTransform;

    private void Update()
    {
        RotateFollowMouse();
    }
    private void RotateFollowMouse()
    {
        // Lấy vị trí của chuột trên màn hình
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // tìm vector hướng từ vị trí player đến con trỏ chuột
        Vector3 dir = (mousePosition - transform.position).normalized;
        // tìm góc xoay
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        // xoay nhân vật
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
