using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.CompareTag("Enemy"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            ObjectPool.Instance.DestroyObject(bullet.gameObject, bullet.bulletType);
        }
    }
}
