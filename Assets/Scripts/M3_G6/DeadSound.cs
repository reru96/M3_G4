using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSound : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    private Kuriboh parentScript;
    public AudioClip deathClip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        parentScript = GetComponentInParent<Kuriboh>();
        if (parentScript != null)
        {
            parentScript.OnDeath += PlayDeathSound;
        }
        else
        {

            audioSource.enabled = true; 

        }
    }
    void PlayDeathSound()
    {
        if (deathClip == null) return;

        
        AudioSource tempSource = gameObject.AddComponent<AudioSource>();
        tempSource.playOnAwake = false;
        tempSource.loop = false;
        tempSource.PlayOneShot(deathClip);


        Destroy(tempSource, deathClip.length + 0.1f);

    }
    private void OnDestroy()
    {
        if (parentScript != null)
            parentScript.OnDeath -= PlayDeathSound;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
