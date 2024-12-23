using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public void StartBtn()
    {
        DataManager.Instance.currentName = nameInput.text;
        SceneManager.LoadScene(1);
    }
    public void RankBtn()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
