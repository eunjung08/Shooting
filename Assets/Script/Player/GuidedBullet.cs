using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuidedBullet : PlayerBullet
{
    Rigidbody2D rb;
    public Transform target;
    public float rotateSpeed;
    public float speed;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        if (EnemyManager.Instance.enemys.Count > 0)
        {
            List<Enemy> targets = EnemyManager.Instance.enemys.OrderByDescending(_ => Vector3.Distance(_.transform.position, transform.position)).ToList();
            target = targets[targets.Count - 1].transform;
        }

    }
    void Update()
    {
        if (target != null)
        {
            transform.up = Vector3.MoveTowards(transform.up, (target.transform.position - transform.position).normalized, rotateSpeed * Time.deltaTime);
        }
        rb.velocity = transform.up * speed;
    }
}
