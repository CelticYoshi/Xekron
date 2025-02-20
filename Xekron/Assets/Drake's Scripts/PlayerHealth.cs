using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int _health = 3;
    public bool _canTakeDamage = true;
    public AudioClip playerHitSound;
    public TextMeshProUGUI playerHealthText;
    private AudioSource playerAudio;
    public ParticleSystem bloodParticle;

    void Start()
    {
        DisplayPlayerHealth();
        playerAudio = GetComponent<AudioSource>();
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        DisplayPlayerHealth();

        yield return new WaitForSeconds(1f);
        _canTakeDamage = true;
    }

    public void DisplayPlayerHealth()
    {
        playerHealthText.text = "HP: " + _health.ToString();
    }

    public int GetPlayerHealth()
    {
        return _health;
    
    }
    
    void OnControllerColliderHit(ControllerColliderHit hit)
     {
        if(hit.collider.gameObject.CompareTag("Enemy") && _canTakeDamage)
        {
            _canTakeDamage = false;
            EnemyAttack enemyAttack = hit.gameObject.GetComponent<EnemyAttack>();
            StartCoroutine(routine:TakeDamage(enemyAttack.Enemydamage()));
            playerAudio.PlayOneShot(playerHitSound, 1.0f);
            bloodParticle.Play();
        }
     }

     public void Update()
     {
        if(_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     }
    
    }
