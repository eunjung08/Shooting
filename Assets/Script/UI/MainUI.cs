using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartBtn();
        }
    }
    public void StartBtn()
    {
        SceneManager.LoadScene(0);
    }
}
