using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimation : MonoBehaviour
{

   
    [SerializeField] private Animator animator;
    [SerializeField] private string deathTrigger = "Die";

   
    [SerializeField] private float destroyDelay = 1f;

   
    private bool isQuitting;

    private void Start()
    {

        var parent = GetComponentInParent<Kuriboh>();
        if (parent != null)
        {
            parent.OnDeath += HandleParentDeath;
        }
    }

    private void OnApplicationQuit() => isQuitting = true;

    private void HandleParentDeath()
    {
        if (isQuitting) return;

        
        transform.SetParent(null);

        
        if (animator != null)
            animator.SetTrigger(deathTrigger);


        Destroy(gameObject, destroyDelay);
    }
}
