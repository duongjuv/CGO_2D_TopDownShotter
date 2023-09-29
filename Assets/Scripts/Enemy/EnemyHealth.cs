using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHP, damage;
    int score = 0;
    [SerializeField] private Animator animatorEnemyPro;
    public int currentHP;
    public bool isDeath;
    //public HealthBar healthBarEnemy;

    private void Start()
    {
        isDeath = false;
        currentHP = maxHP; // Khởi tạo HP hiện tại bằng HP tối đa ban đầu
        //healthBar = GetComponent<HealthBar>(); //  HealthBar gắn với đối tượng này
        //healthBarEnemy.UpdateBar(currentHP, maxHP); // Cập nhật thanh máu ban đầu
        //animatorEnemyPro = GetComponent<Animator>();
    }
    void Update()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
            isDeath = true;
            score += 1;
            Debug.Log(score);
            // healthBarEnemy.UpdateBar(currentHP, maxHP);
            Destroy(gameObject, 0.8f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletToEnemy"))
        {
            // InvokeRepeating("TakeDamage", 0, 0.5f);
            TakeDamage();
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletToEnemy"))
        {
            Debug.Log("CanceInvoke");
            CancelInvoke("TakeDamage");
        }
    }
    public void TakeDamage()
    {
        currentHP -= damage;
        // currentHP = Mathf.Clamp(currentHP, 0, maxHP);
       // healthBarEnemy.UpdateBar(currentHP, maxHP);
    }

}
