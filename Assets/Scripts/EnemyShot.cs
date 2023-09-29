using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public static GameObject Instance;
    [SerializeField] private GameObject target, _bulletEnemyPrefab;
    [SerializeField] float  _rotationSpeed, bulletEnemyForce;


    private Vector3 direction;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(target.transform.position);
        // tìm vector hướng từ vị trí player đến con trỏ chuột
        Vector3 dir = (targetPosition - transform.position).normalized;
        // tìm góc xoay
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg ;
        // xoay nhân vật
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void Shot()
    {
        GameObject bullet = Instantiate(_bulletEnemyPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * bulletEnemyForce, ForceMode2D.Impulse);
        Destroy(bullet, 1f);
    }
}
