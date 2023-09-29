/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int playerCoint = GameManager.coint;
    private int currentCoint;
    private PlayerHealth playerHealth;
    [SerializeField] private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        healthBar = GetComponent<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coint"))
        {
            currentCoint = Random.Range(1, 3);
            playerCoint += currentCoint;
            PlayerPrefs.SetInt("Coint", playerCoint);
            Destroy(collision);
        }
        else if (collision.gameObject.CompareTag("Blood"))
        {
            int restore = Random.Range(10, 20);
            playerHealth.currentHP += restore;
            healthBar.UpdateBar(playerHealth.currentHP, playerHealth.maxHP);
            if (playerHealth.currentHP >= 100)
            {
                playerHealth.currentHP = 100;
                healthBar.UpdateBar(playerHealth.currentHP, playerHealth.maxHP);
            }
            Destroy(collision);
        }

    }
}


*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int playerCoint;
    private int currentCoint;
    private PlayerHealth playerHealth;
    [SerializeField] private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        healthBar = GetComponent<HealthBar>();
        playerCoint = PlayerPrefs.GetInt("Coint", 0); // Lấy giá trị coint từ PlayerPrefs
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coint"))
        {
            currentCoint = Random.Range(1, 3);
            playerCoint += currentCoint;
            PlayerPrefs.SetInt("Coint", playerCoint); // Lưu giá trị coint vào PlayerPrefs
            //Destroy(collision.gameObject); // Để destroy đúng object va chạm
        }
        else if (collision.gameObject.CompareTag("Blood"))
        {
            int restore = Random.Range(10, 20);
            playerHealth.currentHP += restore;
            healthBar.UpdateBar(playerHealth.currentHP, playerHealth.maxHP);
            if (playerHealth.currentHP >= 100)
            {
                playerHealth.currentHP = 100;
                healthBar.UpdateBar(playerHealth.currentHP, playerHealth.maxHP);
            }
           // Destroy(collision.gameObject); // Để destroy đúng object va chạm
        }
    }
}
