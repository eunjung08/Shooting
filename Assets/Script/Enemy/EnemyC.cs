using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyC : Enemy
{

    public Transform firepoint;
    bool canMove = true;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void attack()
    {
        int i = 20;
        for(i=0; i<=20; i++)
        {
            GameObject enemyCBullet = ObjectPool.Instance.GetObject(ObjectTypes.EnemyBullet);
            enemyCBullet.transform.position = firepoint.transform.position;
            enemyCBullet.transform.rotation = firepoint. transform.rotation;
            enemyCBullet.GetComponent<Rigidbody2D>().AddForce(enemyCBullet.transform.up*10, ForceMode2D.Impulse);

            firepoint.Rotate((360 / 20) * Vector3.forward);
            
        }
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
        if(!canMove) { return; }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    IEnumerator Shoot()
    {
        yield return new WaitUntil(() => (transform.position.y <= 2.1f && transform.position.y >= 1.9f));
        canMove = false;
        for(int i = 0; i < 5; i++)
        {
            attack();
            firepoint.Rotate(Vector3.forward * 9);
            yield return new WaitForSeconds(0.75f);
        }
        canMove = true;
    }
}