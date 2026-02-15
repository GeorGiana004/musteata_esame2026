using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHelt : MonoBehaviour
{
    public int health = 5; 
    private bool isDead = false;
    public Slider healthBar;
    public GameObject gameOverScreen;
    public int coin=0;

    
    void Start()
{
    if (healthBar != null)
    {
        healthBar.maxValue = health; // Imposta il massimo dello slider a 5
        healthBar.value = health;    // Riempie la barra al massimo
    }
}
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
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Mostra la scritta Game Over
        }
        Time.timeScale = 0f; // Blocca tutto il gioco
    
    
    }

    private void OnTriggerEnter(Collider other)
    {
       
               if (other.CompareTag("EnemyProjectile")) 
        {
            TakeDamage(1);
            Destroy(other.gameObject); 

           
        }
    }
    private void CoinAdd





}