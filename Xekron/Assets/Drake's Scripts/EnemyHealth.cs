using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int _health = 3;
    public bool _canTakeDamage = true;
    public int _enemyAmount;
     public TextMeshProUGUI enemyText;
    
    public float damageAmount = 1;
    public ParticleSystem bloodParticle;
    public AudioClip EnemyHurt;
    private AudioSource _enemySound;
    

    void Start()
    {
        _enemySound = GetComponent<AudioSource>();
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        

        yield return new WaitForSeconds(.25f);
        _canTakeDamage = true;
    }



    public int GetEnemyHealth()
    {
        return _health;
    
    }
    
    void  OnTriggerEnter(Collider other)
    {
        
    if(other.gameObject.CompareTag("Bullet") && _canTakeDamage)
        {
            Debug.Log("enemy takes damage");
            _enemySound.PlayOneShot(EnemyHurt, 1.0f);
            bloodParticle.Play();
            _canTakeDamage = false;
            //BulletAttack bulletAttack = GetComponent<BulletAttack>();
            StartCoroutine(routine:TakeDamage(1));
        }
    
    }
    public void Update()
     {
        if(_health <= 0)
        {
            this.gameObject.SetActive(false);
            _enemyAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            enemyText.text = "Enemies Remaining: " + _enemyAmount.ToString();
        }
     }}
