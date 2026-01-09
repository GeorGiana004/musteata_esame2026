using UnityEngine;

public class MoveForword : MonoBehaviour
{
   
 
    public GameObject projectilePrefab;
    public Transform shooting_point;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, shooting_point.position, transform.rotation);
        }
    }
}
