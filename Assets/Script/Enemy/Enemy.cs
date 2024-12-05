using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ObjectTypes enemyType;
    public int Hp;
    public float speed;

    public List<DropItem> dropItems = new List<DropItem>();
    
    public void OnDamage(int Dmg)
    {
        Hp -= Dmg;
        if(Hp <=0)
        {
            ItemDrop();
            EnemyManager.Instance.enemys.Remove(this);
            ObjectPool.Instance.DestroyObject(this.gameObject, enemyType);
        }
    }
    void ItemDrop()
    {
        for(int i = 0; i < dropItems.Count; i++)
        {
            float randomValue = UnityEngine.Random.Range(0f, 100f);
            if (randomValue < dropItems[i].probability)
            {
                for(int j = 0; j < dropItems[i].count;j++)
                {
                    GameObject item = ObjectPool.Instance.GetObject(dropItems[i].itemType);
                    float random_x = UnityEngine.Random.Range(-1f, 1f);
                    float random_y = UnityEngine.Random.Range(-1f, 1f);
                    item.transform.position = new Vector3(transform.position.x+random_x, transform.position.y+random_y, 0);
                    item.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
                }
            }
        }
    }
    private void OnBecameInvisible()
    {
        try
        {
            ObjectPool.Instance.DestroyObject(this.gameObject, enemyType);
        }
        catch
        {

        }
    }
}
[Serializable]
public class DropItem
{
    public ObjectTypes itemType;
    public int count;
    public float probability;
}
