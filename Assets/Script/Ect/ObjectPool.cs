using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool instance = null;

    [SerializeField] GameObject playerBulletA_Prefab;
    [SerializeField] GameObject playerBulletB_Prefab;
    [SerializeField] GameObject guidedBullet_Prefab;
    [SerializeField] GameObject enemyBullet_Prefab;
    [SerializeField] GameObject bossBulletA_Prefab;
    [SerializeField] GameObject bossBulletB_Prefab;
    [SerializeField] GameObject enemyA_Prefab;
    [SerializeField] GameObject enemyB_Prefab;
    [SerializeField] GameObject enemyC_Prefab;
    [SerializeField] GameObject HpItem_Prefab;
    [SerializeField] GameObject PowerItem_Prefab;
    [SerializeField] GameObject ScoreItem_Prefab;

    [SerializeField] int playerBulletA_Count;
    [SerializeField] int playerBulletB_Count;
    [SerializeField] int guidedBullet_Count;
    [SerializeField] int enemyBullet_Count;
    [SerializeField] int bossBulletA_Count;
    [SerializeField] int bossBulletB_Count;
    [SerializeField] int enemyA_Count;
    [SerializeField] int enemyB_Count;
    [SerializeField] int enemyC_Count;
    [SerializeField] int HpItem_Count;
    [SerializeField] int PowerItem_Count;
    [SerializeField] int ScoreItem_Count;

    private Queue<GameObject> playerBulletAs = new Queue<GameObject>();
    private Queue<GameObject> playerBulletBs = new Queue<GameObject>();
    private Queue<GameObject> guidedBullets = new Queue<GameObject>();
    private Queue<GameObject> enemyBullets = new Queue<GameObject>();
    private Queue<GameObject> bossBulletA = new Queue<GameObject>();
    private Queue<GameObject> bossBulletB = new Queue<GameObject>();
    private Queue<GameObject> enemyAs = new Queue<GameObject>();
    private Queue<GameObject> enemyBs = new Queue<GameObject>();
    private Queue<GameObject> enemyCs = new Queue<GameObject>();
    private Queue<GameObject> HpItems = new Queue<GameObject>();
    private Queue<GameObject> PowerItems = new Queue<GameObject>();
    private Queue<GameObject> ScoreItems = new Queue<GameObject>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Initialize();
    }
    private void Initialize()
    {
        for(int i =0; i<playerBulletA_Count; i++)
        {
            GameObject obj = Instantiate(playerBulletA_Prefab);
            obj.SetActive(false);
            playerBulletAs.Enqueue(obj);
        }
        for (int i = 0; i < playerBulletB_Count; i++)
        {
            GameObject obj = Instantiate(playerBulletB_Prefab);
            obj.SetActive(false);
            playerBulletBs.Enqueue(obj);
        }
        for (int i = 0; i < guidedBullet_Count; i++)
        {
            GameObject obj = Instantiate(guidedBullet_Prefab);
            obj.SetActive(false);
            guidedBullets.Enqueue(obj);
        }
        for (int i = 0; i < enemyBullet_Count; i++)
        {
            GameObject obj = Instantiate(enemyBullet_Prefab);
            obj.SetActive(false);
            enemyBullets.Enqueue(obj);
        }
        for (int i = 0; i < bossBulletA_Count; i++)
        {
            GameObject obj = Instantiate(bossBulletA_Prefab);
            obj.SetActive(false);
            bossBulletA.Enqueue(obj);
        }
        for (int i = 0; i < bossBulletB_Count; i++)
        {
            GameObject obj = Instantiate(bossBulletB_Prefab);
            obj.SetActive(false);
            bossBulletB.Enqueue(obj);
        }
        for (int i = 0; i < enemyA_Count; i++)
        {
            GameObject obj = Instantiate(enemyA_Prefab);
            obj.SetActive(false);
            enemyAs.Enqueue(obj);
        }
        for (int i = 0; i < enemyB_Count; i++)
        {
            GameObject obj = Instantiate(enemyB_Prefab);
            obj.SetActive(false);
            enemyBs.Enqueue(obj);
        }
        for (int i = 0; i < enemyC_Count; i++)
        {
            GameObject obj = Instantiate(enemyC_Prefab);
            obj.SetActive(false);
            enemyCs.Enqueue(obj);
        }
        for (int i = 0; i < HpItem_Count; i++)
        {
            GameObject obj = Instantiate(HpItem_Prefab);
            obj.SetActive(false);
            HpItems.Enqueue(obj);
        }
        for (int i = 0; i < PowerItem_Count; i++)
        {
            GameObject obj = Instantiate(PowerItem_Prefab);
            obj.SetActive(false);
            PowerItems.Enqueue(obj);
        }
        for (int i = 0; i < ScoreItem_Count; i++)
        {
            GameObject obj = Instantiate(ScoreItem_Prefab);
            obj.SetActive(false);
            ScoreItems.Enqueue(obj);
        }
    }
    public GameObject GetObject(ObjectTypes type)
    {
        GameObject obj = null;
        switch(type)
        {
            case ObjectTypes.PlayerBulletA:
                obj = playerBulletAs.Dequeue();
                break;
            case ObjectTypes.PlayerBulletB:
                obj = playerBulletBs.Dequeue();
                break;
            case ObjectTypes.GuidedBullet:
                obj = guidedBullets.Dequeue();
                break;
            case ObjectTypes.EnemyBullet:
                obj = enemyBullets.Dequeue();
                break;
            case ObjectTypes.BossBulletA:
                obj = bossBulletA.Dequeue();
                break;
            case ObjectTypes.BossBulletB:
                obj = bossBulletB.Dequeue();
                break;
            case ObjectTypes.EnemyA:
                obj = enemyAs.Dequeue();
                break;
            case ObjectTypes.EnemyB:
                obj = enemyBs.Dequeue();
                break;
            case ObjectTypes.EnemyC:
                obj = enemyCs.Dequeue();
                break;
            case ObjectTypes.HpItem:
                obj = HpItems.Dequeue();
                break;
            case ObjectTypes.PowerItem:
                obj = PowerItems.Dequeue();
                break;
            case ObjectTypes.ScoreItem:
                obj = ScoreItems.Dequeue();
                break;
        }
        obj.SetActive(true);
        return obj;
    }
    public void DestroyObject(GameObject obj, ObjectTypes type)
    {
        obj.SetActive(false);
        switch (type)
        {
            case ObjectTypes.PlayerBulletA:
                playerBulletAs.Enqueue(obj);
                break;
            case ObjectTypes.PlayerBulletB:
                playerBulletBs.Enqueue(obj);
                break;
            case ObjectTypes.GuidedBullet:
                guidedBullets.Enqueue(obj);
                break;
            case ObjectTypes.EnemyBullet:
                enemyBullets.Enqueue(obj);
                break;
            case ObjectTypes.BossBulletA:
                bossBulletA.Enqueue(obj);
                break;
            case ObjectTypes.BossBulletB:
                bossBulletB.Enqueue(obj);
                break;
            case ObjectTypes.EnemyA:
                enemyAs.Enqueue(obj);
                break;
            case ObjectTypes.EnemyB:
                enemyBs.Enqueue(obj);
                break;
            case ObjectTypes.EnemyC:
                enemyCs.Enqueue(obj);
                break;
            case ObjectTypes.HpItem:
                HpItems.Enqueue(obj);
                break;
            case ObjectTypes.PowerItem:
                PowerItems.Enqueue(obj);
                break;
            case ObjectTypes.ScoreItem:
                ScoreItems.Enqueue(obj);
                break;
        }
    }

    public static ObjectPool Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
public enum ObjectTypes
{
    PlayerBulletA, PlayerBulletB, GuidedBullet, EnemyBullet, EnemyA, EnemyB, EnemyC, HpItem, PowerItem, ScoreItem, BossBulletA, BossBulletB
}