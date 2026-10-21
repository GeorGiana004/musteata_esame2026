using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHelt : MonoBehaviour
{
    public int health = 5; 
    private bool isDead = false;
    public Slider healthBar;
    public GameObject gameOverScreen;
    public int coin = 0;
    public TextMeshProUGUI coinTextUI;
    public Animator anim; // Variabile per l'animazione del mago

    void Start()
    {
        AggiornaTesto();

        if (healthBar != null)
        {
            healthBar.maxValue = health; // Imposta il massimo dello slider a 5
            healthBar.value = health;    // Riempie la barra al massimo
        }

        // All'inizio spengo la schermata di game over
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
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

    // Unica funzione Die corretta e ripulita
    void Die()
    {
        if (isDead) return; 
        isDead = true;

        Debug.Log("Il player è morto!");

        // Faccio partire l'animazione di morte del mago
        if (anim != null) 
        {
            anim.SetTrigger("Die");
        }

        // 1. Attivo subito la schermata di Game Over
        if (gameOverScreen != null) 
        { 
            gameOverScreen.SetActive(true); 
        }

        // 2. Aspetto 2 secondi prima di bloccare completamente il gioco
        Invoke("MostraFineGiocoPlayer", 2f);
    }

    void MostraFineGiocoPlayer()
    {
        Debug.Log("Sequenza di Game Over completata.");
        
        // Blocco il gioco definitivamente
        Time.timeScale = 0f; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile")) 
        {
            TakeDamage(1);
            Destroy(other.gameObject); 
        }
    }

    public void CoinAdd()
    {
        coin++; 
        Debug.Log("Monete raccolta: " + coin); 
        AggiornaTesto();
    }

    void AggiornaTesto()
    {
        if (coinTextUI != null)
        {
            coinTextUI.text = "COIN: " + coin; // Cambia la scritta a schermo
        }
    }
}