using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHP, minDamage, maxDamage;
    public int currentHP;
    public HealthBar healthBar;
    //public GameManager gameManager;
    [SerializeField] private GameObject gameOverMenu;
   
    private void Start()
    {
        currentHP = maxHP; // Khởi tạo HP hiện tại bằng HP tối đa ban đầu
       // healthBar = GetComponent<HealthBar>(); //  HealthBar gắn với đối tượng này
        healthBar.UpdateBar(currentHP, maxHP); // Cập nhật thanh máu ban đầu
        //gameManager = GetComponent<GameManager>();
    }
    void Update()
    {
        if(currentHP <= 0) // lose
        {
            currentHP = 0;
            healthBar.UpdateBar(currentHP, maxHP);
            //SoundManager.Instance.PlayAudio("PlayerShot");
            gameOverMenu.SetActive(true);
            PlayerPrefs.SetInt("Score", GameManager.score);
        }
        else if(currentHP >= 100)
        {
            currentHP = 100;
            healthBar.UpdateBar(currentHP, maxHP);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLV2") )
        {
            InvokeRepeating("TakeDamage", 0.7f, 0.5f );
            //TakeDamage();
        }
        else if (collision.gameObject.CompareTag("EnemyLV3"))
        {
            InvokeRepeating("TakeDamage", 0.7f, 0.5f);
        }
        else if (collision.gameObject.CompareTag("EnemyLV4"))
        {
            InvokeRepeating("TakeDamage", 0.7f, 0.5f);
        }
        else if (collision.gameObject.CompareTag("EnemyLV1"))
        {
            InvokeRepeating("TakeDamage", 0.7f, 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLV2"))
        {
            CancelInvoke("TakeDamage");
        }
        else if (collision.gameObject.CompareTag("EnemyLV3"))
        {
            CancelInvoke("TakeDamage");
        }
        else if (collision.gameObject.CompareTag("EnemyLV4"))
        {
            CancelInvoke("TakeDamage");
        }
        else if (collision.gameObject.CompareTag("EnemyLV1"))
        {
            CancelInvoke("TakeDamage");
        }
    }
    public void TakeDamage()
    {
        int damage = Random.Range(minDamage, maxDamage);
        currentHP -= damage;
       // currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthBar.UpdateBar(currentHP, maxHP);
    }
}
