using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : MonoBehaviour
{
    public int health = 5;
    public Animator anim; 
    private bool isDead = false;
    public Slider healthBar;
    
    // Scritta iniziale WIN
    public GameObject WinScreen;
    
    // NUOVA VARIABILE: Pannello con l'InputField e il tasto Post Score
    public GameObject inputScorePanel;

    private float combatTimer = 0f;
    private bool timerIsRunning = false;

    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }

        // Assicuriamoci che all'inizio siano tutti e due spenti
        if (WinScreen != null) WinScreen.SetActive(false);
        if (inputScorePanel != null) inputScorePanel.SetActive(false);

        timerIsRunning = true;
        combatTimer = 0f;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            combatTimer += Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage; 
        if (healthBar != null) healthBar.value = health;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; 
        isDead = true;

        timerIsRunning = false;
        Debug.Log("Il drago è morto in " + combatTimer.ToString("F2") + " secondi!");

        if (anim != null) anim.SetTrigger("Die");

        // Dopo 3 secondi fa apparire la scritta WIN
        Invoke("MostraVittoria", 3f);
    }

    void MostraVittoria()
    {
        // Step 1: Appare la scritta WIN
        if (WinScreen != null) 
        { 
            WinScreen.SetActive(true); 
        }

        // Salvo il tempo
        PlayerPrefs.SetFloat("LastPlayerScore", combatTimer);
        PlayerPrefs.Save();

        // Step 2: Aspetto 2 secondi e richiamo la comparsa del pannello per il nome
        Invoke("MostraInserimentoNome", 2f);
    }

  void MostraInserimentoNome()
    {
        // 1. Nascondo la scritta WIN
        if (WinScreen != null)
        {
            WinScreen.SetActive(false);
        }

        // 2. Accendo il pannello del Post Score
        if (inputScorePanel != null)
        {
            inputScorePanel.SetActive(true);
        }

        // 3. Blocco il gioco
        Time.timeScale = 0f; 
    }
}