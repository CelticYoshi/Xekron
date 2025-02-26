using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollectables : MonoBehaviour
{
    public AudioClip collectSound;
    private AudioSource playerAudio;
    public ParticleSystem confettiParticle;
    public int _collectableAmount;
     
     public TextMeshProUGUI collectableText; 
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
         GameObject.Find("Game Manager").GetComponent<GameManager>();
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
             playerAudio.PlayOneShot(collectSound, 1.0f);   
             GameObject.Find("GameManager").GetComponent<GameManager>().UpdateCollectableAmount();
             other.gameObject.SetActive(false);
             
    }
}
}
