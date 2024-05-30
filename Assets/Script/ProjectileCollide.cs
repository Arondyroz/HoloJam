using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bae") || collision.gameObject.CompareTag("Wall"))
             gameObject.SetActive(false);
    }
}
