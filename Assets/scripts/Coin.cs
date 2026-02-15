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
        transform.Rotate(Vector3.right * 100 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other) 
    {
       if (other.CompareTag("Player")) 
    {
        PlayerHelt player = other.GetComponent<PlayerHelt>();
        
        if (player != null)
        {
            player.CoinAdd();
        }

        Debug.Log("Moneta raccolta!");
        Destroy(gameObject); 
    }
    }
}
