using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            ObjectPool.Instance.DestroyObject(bullet.gameObject, bullet.bulletType);
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            ObjectPool.Instance.DestroyObject(bullet.gameObject, bullet.bulletType);
        }
        if(collision.CompareTag("Item"))
        {
            Item item  = collision.GetComponent<Item>();
            ObjectPool.Instance.DestroyObject(item.gameObject, item.itemType);
        }
    }
}
