using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Animator animatorEnemy;
    //[SerializeField] private GameObject _bulletEnemyPrefab;
    [SerializeField] float waitTimeAttack;
    [SerializeField] private GameObject cointPrefab, hpPrefab;

    public GameObject player;

    private EnemyHealth enemyHealth;
    private PlayerHealth playerHealth;
    private int random_Loot_Generation;
    public float rotationSpeed = 6000f; // Tốc độ xoay

    //public EnemyShot enemyShot; 
    //[SerializeField] private GameObject _bulletPrefab;
    // private Vector2 _movementInput, _smoothMovementInput, _movementInputSmoothVelocity;

    float distanceEnemy, timerShot;
    private Vector2 movement;
    private Vector3 direction;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        animatorEnemy = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && !enemyHealth.isDeath) // Kiểm tra xem player đã được tìm thấy chưa
        {
            //if (enemyHealth.currentHP <= 0)
            // {
            //  Debug.Log("Enemy Die");
            // }
            //else // enemy còn sống
            // {
            direction = player.transform.position - transform.position;
            if (player.transform.position.x < transform.position.x)
            {
                Quaternion targetRotation = Quaternion.Euler(0f, 180f, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            DistanceWithPlayer();
            direction.Normalize();
            movement = direction;
            // }

            /*// Tính góc quay để hướng về player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //angle += 90f;
            rb.rotation = angle;
            
            
            transform.rotation = Quaternion.Euler(0f, 0f, angle);*/
        }
        

    }
    private void FixedUpdate()
    {
        if (distanceEnemy >= 0.1f && distanceEnemy <= 10f) // khoang cach enemy co the di chuyen ve phia player
        {
            if (enemyHealth.isDeath) // enemy đã hẹo
            {
                animatorEnemy.SetBool("SetEnemyAttack", false);
                animatorEnemy.SetBool("SetEnemyDie", true);
                animatorEnemy.SetBool("SetEnemyRun", false);
                animatorEnemy.SetBool("SetEnemyIdle", false);
                RandomGameObject();
                
            }
            else // enemy còn sống
            {
                moveCharacter(movement);
                animatorEnemy.SetBool("SetEnemyAttack", false);
                animatorEnemy.SetBool("SetEnemyDie", false);
                animatorEnemy.SetBool("SetEnemyRun", true);
                animatorEnemy.SetBool("SetEnemyIdle", false);
            }

        }
        else // ngoai tam di chuyen cua player
        {
            animatorEnemy.SetBool("SetEnemyAttack", false);
            animatorEnemy.SetBool("SetEnemyDie", false);
            animatorEnemy.SetBool("SetEnemyRun", false);
            animatorEnemy.SetBool("SetEnemyIdle", true);
        }

    }

    // khoang cach giua enemy va player
    void DistanceWithPlayer()
    {
        distanceEnemy = (player.transform.position - transform.position).magnitude;
        timerShot += Time.deltaTime;

        if (distanceEnemy <= 0.1f)
        {
            if (timerShot >= waitTimeAttack)
            {
                timerShot = 0;
                Attack();
            }
        }
    }
    void moveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * moveSpeed * Time.deltaTime));

    }
    public void Attack()
    {       
        animatorEnemy.SetBool("SetEnemyDie", false);
        animatorEnemy.SetBool("SetEnemyRun", false);
        animatorEnemy.SetBool("SetEnemyIdle", false);
        animatorEnemy.SetBool("SetEnemyAttack", true);       
    }

    public void RandomGameObject()
    {
        random_Loot_Generation = Random.Range(1, 5);
        if (random_Loot_Generation == 1 || random_Loot_Generation == 2 || random_Loot_Generation == 3)
        {
            // rơi vàng
            GameObject coint = Instantiate(cointPrefab, transform.position, Quaternion.identity);
            Destroy(coint, 7f);

        }
        /*else if (random_Loot_Generation == 4)
        {
            // rơi máu
            GameObject hp = Instantiate(hpPrefab, transform.position, Quaternion.identity);
            Destroy(hp, 10f);
        }*/
        else
        {
            // ko có gì            
        }
    }

}
