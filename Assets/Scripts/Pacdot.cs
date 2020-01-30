using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour
{
    public AudioSource pelletSource;
    void Start()
    {
        pelletSource = GetComponent<AudioSource>();
    }
    void Collision2D(Collider2D co)
    {
        if (co.name == "demagorgon")
        {
            pelletSource.Play();
        }
    }
}