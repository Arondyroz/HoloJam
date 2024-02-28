using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject deadUI;
    public GameObject winUI;
    public void DeactiveGO(GameObject go)
    {
        go.SetActive(false);
    }
    
    public void LoadScene()
    {
        StartCoroutine(CheckActiveGo());
    }

    IEnumerator CheckActiveGo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    public void DeadUI(bool check)
    {
        deadUI.SetActive(check);
    }

    public void WinUI(bool check)
    {
        winUI.SetActive(check);
    }
}
