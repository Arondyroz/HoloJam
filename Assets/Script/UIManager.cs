using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject deadUI;
    public GameObject winUI;
    public GameObject phase2UI;
    public GameObject phase3UI;

    private void Update()
    {
        if (GameManager.instance.TimeCheck <= 90f)
            phase2UI.SetActive(true);

        if (GameManager.instance.TimeCheck <= 45f)
            phase3UI.SetActive(true);
    }
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
        winUI.SetActive(check);
    }
}
