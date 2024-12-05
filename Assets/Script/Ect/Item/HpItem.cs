using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : Item
{
    public override void GiveEffect()
    {
        GameManager.Instance.player.hp++;
        ObjectPool.Instance.DestroyObject(this.gameObject, itemType);
    }
}
