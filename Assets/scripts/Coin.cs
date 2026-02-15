using UnityEngine;

public class Coin : MonoBehaviour
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
        if (other.CompareTag("Player")) 
        {
            // Cerca lo script del mago e aggiungi un punto
            other.GetComponent<PlayerHelt>().AggiungiMoneta();
            Destroy(gameObject); // La moneta sparisce
        }
    }
}
