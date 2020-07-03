using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBar : MonoBehaviour
{
    void Die()
    {
        GetComponent<PlayerControl>().enabled = false;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }
    const float MAXHEALTH = 100f;
    float health;
    // Start is called before the first frame update
   private void Start()
    {
        health = MAXHEALTH;
    }

    
    void Update()
    {
        
    }
}
