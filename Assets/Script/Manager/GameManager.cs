using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Player player;

    public int score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
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
