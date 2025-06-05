using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource ost;

    void Start()
    {
        ost = GetComponent<AudioSource>();
        if (!ost.isPlaying)
        {
            ost.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !ost.isPlaying)
        {
            ost.Play();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ost.Stop();
        }
    }

}
