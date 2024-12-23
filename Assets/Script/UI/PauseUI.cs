using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public GameObject parent;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            NoBtn();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            YesBtn();
        }
    }
    public void YesBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void NoBtn()
    {
        Time.timeScale = 1;
        parent.SetActive(false);
    }
}
