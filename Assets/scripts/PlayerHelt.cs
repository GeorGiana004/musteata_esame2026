using UnityEngine;

public class PlayerHelt : MonoBehaviour
{
    public int health = 5; 
    private bool isDead = false;
    public Slider healthBar;

    
    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        Debug.Log("Mago colpito! Vita rimanente: " + health);
        if (healthBar != null)
        {
            healthBar.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Il Mago è morto!");
    
    }

    private void OnTriggerEnter(Collider other)
    {
       
               if (other.CompareTag("EnemyProjectile")) 
        {
            TakeDamage(1);
            Destroy(other.gameObject); // Distruggi il proiettile nemico
        }
    }
}