using UnityEngine;

public class LifeController : MonoBehaviour
{

    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    public int TakeHeal(int amount)
    {


        health = Mathf.Max(health + amount, 0);
        Debug.Log("Il giocatore ha: " + health + " hp");
        return health;

    }

    public int TakeDamage(int damage)
    {
        Debug.Log("Il personaggio ha: " + health + " hp");
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("il giocatore è stato sconfitto");
            
        }
        
        return TakeHeal(-damage);
    }


    // Update is called once per frame
    void Update()
    {
      
    }

}
