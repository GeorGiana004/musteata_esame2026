using UnityEngine;


public class DragonHealth : MonoBehaviour
{
    public int health = 5;
    public Animator anim; 
    private bool isDead = false;
    private Slider healthBar;

   

    void Start()
    {
        // Imposta la barra al massimo all'inizio                    
        if (HealthBar != null)
        {
            HealthBar.maxValue = health;
            HealthBar.value = health;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        health -= damage;
        
        Debug.Log("Colpito! Vita attuale: " + health);

        if (anim != null)
        {
            if (health <= 0)
            {
                Die();
            }
            else
            {
                anim.SetTrigger("GetHit");
                Debug.Log("Trigger GetHit inviato correttamente");
            }
            if (HealthBar != null)
        {
            HealthBar.value = health;
        }
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("ESEGUO TRIGGER MORTE");

        if (anim != null) anim.SetTrigger("Die"); 
        Debug.Log("Il drago è morto.");
    }
}