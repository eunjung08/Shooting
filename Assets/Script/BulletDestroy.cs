using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x > 1.1) { Destroy(this.gameObject); }
        if (pos.x < -0.1) { Destroy(this.gameObject); }
        if (pos.y > 1.1) { Destroy(this.gameObject); }
        if (pos.y < -0.1) { Destroy(this.gameObject); }
    }
}
