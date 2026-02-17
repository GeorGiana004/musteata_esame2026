using UnityEngine;

public class ProjectileMove : MonoBehaviour
{    public float speed= 40f;
     private float NormalSpeed;//
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           NormalSpeed = speed;
        speed= NormalSpeed*1.5f;
    }

    // Update is called once per frame
    void Update()
    {
      
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }
    
}
