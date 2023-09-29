using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private float _bulletSpeed, waitFire, bulletForce;
    [SerializeField] private GameObject _bulletPrefab;
    
    float timer;

    //private bool _fireContinue;
    // Start is called before the first frame update
    void Start()
    {
       // timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OnFire();
        //_fireContinue = true;
    }
    private void OnFire()
    {
         timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {        
            if(timer >= waitFire)
            {               
                timer = 0;
                FireBullet();
            }       
            
        }
    }
    private void FireBullet()
    {

        GameObject bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        SoundManager.Instance.PlayAudio("PlayerShot");
        Destroy(bullet, 1f);
    }
}
