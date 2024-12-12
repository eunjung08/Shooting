using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemyA : Enemy
{
    Vector3 dir = Vector3.down;
    public Transform firepoint;
    public float rotateSpeed;
    public float attackDelay;
    void Start()
    {
        StartCoroutine(Attack());
    }
    private void Update()
    {
        if (Hp <= 0)
        {
            ItemDrop();
            EnemyManager.Instance.enemys.Remove(this);
            ObjectPool.Instance.DestroyObject(this.gameObject, enemyType);
        }
        Move();
    }

    private void Move()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    //private void Attack()
    //{
    //        //Vector3 target = GameManager.Instance.player.transform.position;
    //        //GameObject BulletA = Instantiate(enemyBulletPrefab);
    //        //GameObject BulletB = Instantiate(enemyBulletPrefab);
    //        //GameObject BulletC = Instantiate(enemyBulletPrefab);
    //        //BulletA.transform.position = firepoint.transform.position;
    //        //BulletB.transform.position = firepoint.transform.position;
    //        //BulletC.transform.position = firepoint.transform.position;
    //        //BulletA.transform.up = Vector3.MoveTowards(firepoint.transform.right*1f, (firepoint.transform.position - target).normalized, rotateSpeed);
    //        //BulletB.transform.up = Vector3.MoveTowards(firepoint.transform.right*-1f, (firepoint.transform.position - target).normalized, rotateSpeed);
    //        //BulletC.transform.up = Vector3.MoveTowards(firepoint.transform.right*0f, (firepoint.transform.position - target).normalized, rotateSpeed);
    //        //BulletA.GetComponent<Rigidbody2D>().AddForce(BulletA.transform.up*-10, ForceMode2D.Impulse);
    //        //BulletB.GetComponent<Rigidbody2D>().AddForce(BulletB.transform.up*-10, ForceMode2D.Impulse);
    //        //BulletC.GetComponent<Rigidbody2D>().AddForce(BulletC.transform.up*-10, ForceMode2D.Impulse);

            
    //}
    IEnumerator Attack()
    {
        
        //Vector3 target = GameManager.Instance.player.transform.position;
        //while(!((transform.up.x >= (transform.position - target).normalized.x - 0.1f
        //    && transform.up.x <= (transform.position - target).normalized.x + 0.1f) &&
        //    (transform.up.y >= (transform.position - target).normalized.y - 0.1f
        //    && transform.up.y <= (transform.position - target).normalized.y + 0.1f)))
        //{
        //    for(int i=0; i<3; i++)
        //    { 
        //        yield return new WaitForSeconds(1f);
        //        Attack();
        //    }
        //}
        while(true)
        {
            Vector3 dir = GameManager.Instance.player.transform.position - firepoint.position;
            firepoint.up = dir;
            firepoint.Rotate(Vector3.forward * -15);
            for (int i = 0; i<3; i++)
            {
                GameObject bullet =ObjectPool.Instance.GetObject(ObjectTypes.EnemyBullet);
                bullet.transform.position=firepoint.transform.position;
                bullet.transform.rotation = firepoint.transform.rotation;
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up*5, ForceMode2D.Impulse);

                firepoint.Rotate(Vector3.forward * 15);
            }
            yield return new WaitForSeconds(attackDelay);
        }
        
    }
}
