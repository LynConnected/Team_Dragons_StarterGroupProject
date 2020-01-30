using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 10f;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("demagorgon"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider2D demagorgon)
    {
        GetComponent<SpriteRenderer>().enabled = false;
        
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}