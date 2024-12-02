using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public ObjectTypes bulletType;
    public int atk;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().OnDamage(atk);
            ObjectPool.Instance.DestroyObject(this.gameObject, bulletType);
        }
    }
}
