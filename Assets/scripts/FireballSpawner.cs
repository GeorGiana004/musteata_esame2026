using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    
   public GameObject fireballPrefab; 
    public float spawnRate = 1.0f;    
    public float areaWidth = 10f; 

    // Salviamo la posizione iniziale per oscillare attorno ad essa
    private Vector3 posizioneIniziale;

    void Start()
    {
        posizioneIniziale = transform.position; 
        InvokeRepeating("SpawnFireball", 1.0f, spawnRate);  
    }

    void Update()
    {
        // Mathf.Sin per far oscillare lo spawne  
        float oscillazione = Mathf.Sin(Time.time * 2f) * areaWidth;

        // <->spawner sulla Z 
         transform.position = new Vector3(posizioneIniziale.x, posizioneIniziale.y, posizioneIniziale.z + oscillazione);
    }

    void SpawnFireball()
    {
        // crea palla esattamente dove si trova lo spawner in quel momento
        Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    }
    
}

   

