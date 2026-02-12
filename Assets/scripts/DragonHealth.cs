using UnityEngine;

public class DragonHealth : MonoBehaviour
{
    public int health = 5;
    public Animator anim; 
    private bool isDead = false;

    void Start()
    {
        
       
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
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("ESEGUO TRIGGER MORTE");

        if (anim != null) anim.SetTrigger("Die"); 

        // Disabilita tutti i collider
        Collider[] allColliders = GetComponentsInChildren<Collider>();
        foreach (Collider c in allColliders) c.enabled = false;

        Debug.Log("Il drago è morto.");
    }
}