using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; 
   private float spawnPosZ = 2f;  

    void Start()
    {
        InvokeRepeating("SpawnRandomCoin", 3f, 5f);
    }

    void SpawnRandomCoin()
{
    // Spawna tra 2 e 10 metri davanti allo spawner
    float randomZ = Random.Range(2f, 10f); 
    

    Vector3 spawnPos = new Vector3(0, 0.5f, transform.position.z + randomZ); 
    
    Instantiate(coinPrefab, spawnPos, coinPrefab.transform.rotation);
}
}