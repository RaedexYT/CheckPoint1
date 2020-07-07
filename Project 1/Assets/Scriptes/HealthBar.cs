using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour

{
    const float MAXHEALTH = 100f;
    float health;
    void Die()
    {
        GetComponent<PlayerControl>().enabled = false;
        GetComponent<Animator>().SetBool("dead", true);
    }
    public Slider healthSlider;
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthSlider.value = health / MAXHEALTH;
    
}
    // Start is called before the first frame update
   private void Start()
    {
        health = MAXHEALTH;
    }

    
    void Update()
    {
        
    }
    public void GetHealth(float amount)
    {
        health += amount; if (health > MAXHEALTH)
        {
            health = MAXHEALTH;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heal"))
        {
            GetHealth(5);
            Destroy(other.gameObject);
        }
        // UPDATE THE SLIDER
        healthSlider.value = health / MAXHEALTH;
    }



}

