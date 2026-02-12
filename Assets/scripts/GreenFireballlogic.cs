using UnityEngine;

public class GreenFireballlogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().WakeUp();
        Debug.Log("Palla verde creata e pronta a colpire!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter(Collider other)
{
   // Cerca lo script DragonHealth nell'oggetto colpito o in tutti i suoi "genitori"
    DragonHealth healthScript = other.GetComponentInParent<DragonHealth>();

    if (healthScript != null)
    {
        healthScript.TakeDamage(1);
        Debug.Log("Danno inflitto al Drago!");
        Destroy(gameObject); // Distruggi la palla dopo il colpo
    }
   
    // Ignora il giocatore e gli effetti visivi
    if (other.CompareTag("Player") || other.name.Contains("VFX")) return;

    Debug.Log("Ho toccato: " + other.gameObject.name);

    if (other.CompareTag("Enemy"))
    {
        // Cerca lo script DragonHealth nell'oggetto colpito O nei suoi genitori
        DragonHealth health = other.GetComponentInParent<DragonHealth>();

        if (health != null)
        {
            health.TakeDamage(1);
            Debug.Log("<color=green>COLPITO! Vita drago diminuita.</color>");
        }
        
        Destroy(gameObject); // Distruggi la palla dopo il colpo
    }

    
    // Opzionale: distruggi se tocca l'ambiente (es. pavimento)
    if (other.CompareTag("Player") || other.name.Contains("VFX")) 
    {
     return; // Non fare nulla se colpisci il player o un effetto
    }
  }
}
