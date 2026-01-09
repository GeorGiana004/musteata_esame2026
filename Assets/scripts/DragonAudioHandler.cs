using UnityEngine;

public class DragonAudioHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  [Header("Audio Settings")]
    public AudioSource audioSource;
    
    [Header("Clips")]
    public AudioClip roarClip;
    public AudioClip clawClip; 
     public AudioClip flameClip; 

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayRoar()
    {
        if (audioSource != null && roarClip != null)
        {
            audioSource.PlayOneShot(roarClip);
        }
        else
        {
            Debug.LogWarning("Missing AudioSource or AudioClip on " + gameObject.name);
        }
    }
    public void PlayClaw()
    {
        if (audioSource != null && clawClip != null)
            audioSource.PlayOneShot(clawClip);
    }
    public void PlayFlame()
    {
        if (audioSource != null && flameClip != null)
            audioSource.PlayOneShot(flameClip );
    }
}
