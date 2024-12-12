using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : Enemy
{
    public List<Transform> bulletPoints = new List<Transform>();

    public List<int> spellIndexes = new List<int>();
    Coroutine currentSpell;

    bool canAttack = false;

    public float spellTimer;
    public float currentspellTime;
    // Update is called once per frame
    void Update()
    {
        Move();
        SpellChange();
    }
    void SpellChange()
    {
        if(!canAttack) { return; }
        if (Hp > 0 && spellTimer > currentspellTime) { return; }
        if (currentSpell != null)
        {
            StopCoroutine(currentSpell);
        }
        currentspellTime = 0;
        Hp = 100;
        //int spellIndex = spellIndexes[Random.Range(0, spellIndexes.Count)];
        int spellIndex = 2;
        spellIndexes.Remove(spellIndex);
        currentSpell = StartCoroutine("Spell" + spellIndex);
    }
    IEnumerator Spell1()
    {
        //while (true)
        {
            int count = 20;
            for(int i = 0; i < count; i++)
            {
                GameObject bullet = ObjectPool.Instance.GetObject(ObjectTypes.EnemyBullet);
                bullet.transform.position = bulletPoints[0].position;
                bullet.transform.rotation = bulletPoints[0].rotation;
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up*5, ForceMode2D.Impulse);
                bulletPoints[0].transform.Rotate(Vector3.forward * (360 / count));
            }
            bulletPoints[0].Rotate(Vector3.forward * ((360 / count) / 3));
            yield return new WaitForSeconds(0.75f);
        }
    }
    IEnumerator Spell2()
    {
        while (true)
        {
            for(int i = 0; i < 3; i++)
            {
                GameObject bulletA = ObjectPool.Instance.GetObject(ObjectTypes.BossBulletA);
                bulletA.transform.position = bulletPoints[0].position;
                bulletA.GetComponent<Rigidbody2D>().AddForce((GameManager.Instance.player.transform.position) - bulletA.transform.position.normalized * 3, ForceMode2D.Impulse);
                while (bulletA.activeSelf)
                {
                    GameObject bulletB = ObjectPool.Instance.GetObject(ObjectTypes.BossBulletB);
                    Vector3 pos = new Vector3(bulletA.transform.position.x + Random.Range(-0.7f, 0.7f), bulletA.transform.position.y + Random.Range(-0.7f, 0.7f),0);
                    bulletB.transform.position = pos;
                    bulletB.transform.Rotate(Vector3.forward * Random.Range(0, 360f));
                    DeleteBulletB(bulletB);
                    yield return new WaitForSeconds(0.02f);
                }
            }

            for(int i = 0; i <5; i++)
            {
                Vector3 dir = GameManager.Instance.player.transform.position - bulletPoints[0].position;
                bulletPoints[0].up = dir.normalized;
                bulletPoints[0].Rotate(Vector3.forward * 30);
                for(int j = 0; j<5; j++)
                {
                    GameObject bullet = ObjectPool.Instance.GetObject(ObjectTypes.EnemyBullet);
                    bullet.transform.position = bulletPoints[0].transform.position;
                    bullet.transform.rotation = bulletPoints[0].transform.rotation;
                    bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 7, ForceMode2D.Impulse);
                    bulletPoints[0].transform.Rotate(Vector3.forward * -15);
                }
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
    IEnumerator DeleteBulletB(GameObject bullet)
    {
        yield return new WaitForSeconds(4f);
        ObjectPool.Instance.DestroyObject(bullet, ObjectTypes.BossBulletB);
    }
    IEnumerator Spell3()
    {
        Debug.Log(3);
        yield return null;
    }
    IEnumerator Spell4()
    {
        Debug.Log(4);
        yield return null;
    }
    void Move()
    {
        if (transform.position.y <= 3) { canAttack = true; return; }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
