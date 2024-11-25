using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyB : Enemy
{
    public float rotateSpeed;
    bool canMove = true;
    Vector3 dir = Vector3.down;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if(!canMove) { return; }
        transform.position += dir * speed * Time.deltaTime;
    }
    IEnumerator Shoot()
    {
        yield return new WaitUntil(() => (transform.position.y <= 4.1f && transform.position.y >= 3.9f));
        canMove = false;
        //타겟
        Vector3 target = GameManager.Instance.player.transform.position;
        //회전
        while(!((transform.up.x >= (transform.position - target).normalized.x - 0.1f
            && transform.up.x <= (transform.position - target).normalized.x + 0.1f) &&
            (transform.up.y >= (transform.position - target).normalized.y - 0.1f
            && transform.up.y <= (transform.position - target).normalized.y + 0.1f)))
        {
            transform.up = Vector3.MoveTowards(transform.up, (transform.position - target).normalized, rotateSpeed);
            yield return new WaitForSeconds(0.05f);
        }
        Debug.Log(1);
        yield return new WaitForSeconds(1f);
        //발사
        canMove = true;
        dir = transform.up * -1;
        speed = 20;
    }
}
