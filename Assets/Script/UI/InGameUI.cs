using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    private static InGameUI instance;

    public List<Image> hpImages = new List<Image>();
    public TextMeshProUGUI scoreUI;
    public Slider bossHpBar;
    public GameObject pauseUI;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (bossHpBar.gameObject.activeSelf)
        {
            bossHpBar.value = (float)GameManager.Instance.boss.Hp / GameManager.Instance.boss.maxHp;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void EnableBossHpBar()
    {
        bossHpBar.gameObject.SetActive(true);
    }
    public void UpdateScoreUI(int score)
    {
        scoreUI.text = score.ToString("00000000");
    }
    public void UpdatePlayerHpUI(int hp)
    {
        for(int i = 0; i < hpImages.Count; i++)
        {
            hpImages[i].gameObject.SetActive(i < hp);
        }
    }

    public static InGameUI Instance
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
