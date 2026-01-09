using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float zRange = 10f;
    public GameObject projectilePrefab;
    public Transform shooting_point;
    private Animator playerAnim;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        
        // Muove il personaggio avanti e indietro sulla linea retta (Z)
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed, Space.World);

        // 2. LIMITI DELLA STRADA
        if (transform.position.z > zRange) 
        {
          transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zRange) 
        {
        transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        // 3. GIRARE IL PERSONAGGIO 
        if (verticalInput > 0.1f)
        {
          
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (verticalInput < -0.1f)
        {
     
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // 4. ANIMAZIONI
        playerAnim.SetBool("isMoving", Mathf.Abs(verticalInput) > 0.1f);

        // 5. SPARO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("Attack_trig");
            Instantiate(projectilePrefab, shooting_point.position, transform.rotation);
        }
    }
    public void Hit() { }
}