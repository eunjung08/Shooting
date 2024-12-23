using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : Item
{
    public override void GiveEffect()
    {
        GameManager.Instance.AddScore(100);
        ObjectPool.Instance.DestroyObject(this.gameObject, itemType);
    }
}
