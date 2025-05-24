using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<LifeController>().TakeDamage(damage);
            Debug.Log("BOOOM");
           
        } 
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
