using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectables : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource playerAudio;
    public ParticleSystem confettiParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
             confettiParticle.Play();
             other.gameObject.SetActive(false);
             playerAudio.PlayOneShot(collectSound, 1.0f);    
             
    }
}
}
