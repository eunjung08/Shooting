using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : Item
{
    public override void GiveEffect()
    {
        if(GameManager.Instance.player.power < 3)
        {
            GameManager.Instance.player.power++;
            ObjectPool.Instance.DestroyObject(this.gameObject, itemType);
        }
    }
}
