using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public Ranking ranking = new Ranking();
    public int currentScore;
    public string currentName;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadRank();
    }
    private void LoadRank()
    {
        try
        {
            string path = Path.Combine(Application.dataPath, "RankData.json");
            string jsonData = File.ReadAllText(path);
            ranking = JsonUtility.FromJson<Ranking>(jsonData);
        }
        catch
        {

        }
    }
    public void UpdateRank()
    {
        ranking.ranks.Add(new PlayerData(currentName, currentScore));
        ranking.ranks = ranking.ranks.OrderByDescending(_ => _.score).ToList();
        if (ranking.ranks.Count >= 6)
        {
            ranking.ranks.RemoveAt(5);
        }

        string path = Path.Combine(Application.dataPath, "RankData.json");
        string jsonData = JsonUtility.ToJson(ranking);
        File.WriteAllText(path, jsonData);
    }
    public static DataManager Instance
    {
        get
        {
            if( instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
[Serializable]
public class Ranking
{
    public List<PlayerData> ranks = new List<PlayerData>();
}
[Serializable]
public class PlayerData
{
    public string name;
    public int score;

    public PlayerData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}