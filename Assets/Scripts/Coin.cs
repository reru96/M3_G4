using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coin++;
            Debug.Log("numero coin:" + coin);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
