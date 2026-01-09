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
   if (other.CompareTag("Enemy"))
    {
        Debug.Log("<color=lime>MAGO HA COLPITO IL DRAGO!</color>"); // Messaggio verde in console

        DragonHealth health = other.GetComponent<DragonHealth>();
        if (health != null)
        {
            health.TakeDamage(1); // Toglie vita e attiva l'animazione GetHit
        }
        Destroy(gameObject); // La palla verde sparisce
        }
        Debug.Log("Ho toccato un oggetto che si chiama: " + other.gameObject.name);

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("<color=lime>MAGO HA COLPITO IL DRAGO!</color>");
        }
    }
}


