using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class EnemyA : Enemy
{
    Vector3 dir = Vector3.down;
    public Transform firepoint;
    public float rotateSpeed;
    void Start()
    {
        StartCoroutine(Shoot());
    }
    private void Update()
    {
        Move();
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.y < -0.05) { Destroy(this.gameObject); }
    }

    private void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void Attack()
    {
            Vector3 target = GameManager.Instance.player.transform.position;
            GameObject BulletA = Instantiate(enemyBulletPrefab);
            GameObject BulletB = Instantiate(enemyBulletPrefab);
            GameObject BulletC = Instantiate(enemyBulletPrefab);
            BulletA.transform.position = firepoint.transform.position;
            BulletB.transform.position = firepoint.transform.position;
            BulletC.transform.position = firepoint.transform.position;
            BulletA.transform.up = Vector3.MoveTowards(firepoint.transform.right*1f, (firepoint.transform.position - target).normalized, rotateSpeed);
            BulletB.transform.up = Vector3.MoveTowards(firepoint.transform.right*-1f, (firepoint.transform.position - target).normalized, rotateSpeed);
            BulletC.transform.up = Vector3.MoveTowards(firepoint.transform.right*0f, (firepoint.transform.position - target).normalized, rotateSpeed);
            BulletA.GetComponent<Rigidbody2D>().AddForce(BulletA.transform.up*-10, ForceMode2D.Impulse);
            BulletB.GetComponent<Rigidbody2D>().AddForce(BulletB.transform.up*-10, ForceMode2D.Impulse);
            BulletC.GetComponent<Rigidbody2D>().AddForce(BulletC.transform.up*-10, ForceMode2D.Impulse);

            
    }
    IEnumerator Shoot()
    {
        
        Vector3 target = GameManager.Instance.player.transform.position;
        while(!((transform.up.x >= (transform.position - target).normalized.x - 0.1f
            && transform.up.x <= (transform.position - target).normalized.x + 0.1f) &&
            (transform.up.y >= (transform.position - target).normalized.y - 0.1f
            && transform.up.y <= (transform.position - target).normalized.y + 0.1f)))
        {
            for(int i=0; i<3; i++)
            { 
                yield return new WaitForSeconds(1f);
                Attack();
            }
        }
        
    }
}
