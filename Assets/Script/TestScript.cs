using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public void ActiveGameObject()
    {
        this.gameObject.SetActive(false);
    }

    public void ChangeColor()
    {
        this.gameObject.GetComponent<Image>().material.SetColor("_Color", Color.red);
    }


}
