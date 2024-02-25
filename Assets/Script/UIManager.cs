using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void DeactiveGO(GameObject go)
    {
        go.SetActive(false);
    }    
}
