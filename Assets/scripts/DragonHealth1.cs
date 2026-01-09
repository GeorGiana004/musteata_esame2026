using UnityEngine;

public class DragonHealth : MonoBehaviour
{
 public int health = 5; // Muore al quinto colpo
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
        {
            if (isDead) return;
            health -= damage;

        // controllo  se il Renderer esiste prima di usarlo -- feedbak visivo 
        
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null) 
        {
            rend.material.color = Color.red;
            Invoke("ResetColor", 0.1f);
        }

        if (health <= 0) Die();
        else anim.SetTrigger("GetHit");
        }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("Die"); 
        // Disabilita il collider così le palle di fuoco gli passano attraverso
        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = false;
            
        Debug.Log("Il drago è stato sconfitto!");
    }
    void ResetColor() {
    GetComponentInChildren<Renderer>().material.color = Color.white;
    }
}