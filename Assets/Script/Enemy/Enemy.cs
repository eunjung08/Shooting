using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public int Hp;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDamage(int Dmg)
    {
        Hp -= Dmg;
        if(Hp <=0)
        {
            EnemyManager.Instance.enemys.Remove(this);
            Destroy(this.gameObject);
        }
    }
}
