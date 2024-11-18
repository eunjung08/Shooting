using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp;
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
            Destroy(this.gameObject);
        }
    }
}
