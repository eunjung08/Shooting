using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuidedBullet : PlayerBullet
{
    Transform target;
    void Update()
    {
        target = EnemyManager.Instance.enemys[0].transform;
    }
}
