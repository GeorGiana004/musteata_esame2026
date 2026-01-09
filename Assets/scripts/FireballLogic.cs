using UnityEngine;

public class FireBall_ : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto colpito ha il tag Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Hit!");
            
            Destroy(gameObject); 
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
}
}
