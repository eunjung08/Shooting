using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankUI : MonoBehaviour
{
    public List<GameObject> ranks = new List<GameObject>();
    private void Start()
    {
        for(int i = 0; i < ranks.Count; i++)
        {
            if(i < DataManager.Instance.ranking.ranks.Count)
            {
                ranks[i].SetActive(true);
                ranks[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = DataManager.Instance.ranking.ranks[i].name;
                ranks[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = DataManager.Instance.ranking.ranks[i].score.ToString("0000");
            }
            else
            {
                ranks[i].SetActive(false);
            }
        }
    }
    public void homeBtn()
    {
        SceneManager.LoadScene(0);
    }
}
