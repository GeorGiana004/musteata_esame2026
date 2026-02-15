using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : MonoBehaviour
{
    public int health = 5;
    public Animator anim; 
    private bool isDead = false;
    public Slider healthBar;
    public GameObject WinScreen;

    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }

        // Assicurati che la schermata Win sia spenta all'inizio
        if (WinScreen != null)
        {
            WinScreen.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        anim.SetTrigger("Die");
        
    if (WinScreen != null) WinScreen.SetActive(true);
        health -= damage;
        Debug.Log("Colpito! Vita attuale: " + health);

        if (healthBar != null)
        {
            healthBar.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
        else if (anim != null)
        {
            anim.SetTrigger("GetHit");
            Debug.Log("Trigger GetHit inviato correttamente");
        }
    }

    void Die()
    {
        if (isDead) return; 
        isDead = true;

        Debug.Log("Il drago è morto.");

        if (anim != null) 
        {
            anim.SetTrigger("Die");
        }

        
        if (WinScreen != null)
        {
            WinScreen.SetActive(true);
        }

    }


  /*  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile")) 
        {
            TakeDamage(1);
            Destroy(other.gameObject); 
        }
    }*/
}