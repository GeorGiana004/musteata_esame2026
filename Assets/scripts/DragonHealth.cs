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

        if (WinScreen != null)
        {
            WinScreen.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

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
         Invoke("MostraVittoria", 3f);

      /*  if (WinScreen != null)
        {
            WinScreen.SetActive(true); 
            Debug.Log("win screen attivato " + health);
        }
       

        Time.timeScale = 0f; // Ferma il gioco*/
    }
    void MostraVittoria()
    {
       if (WinScreen != null) 
        {
            WinScreen.SetActive(true); 
            Debug.Log("Schermata Vittoria attivata ora!");
        }

        Time.timeScale = 0f; 
    }
}