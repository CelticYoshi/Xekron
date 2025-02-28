using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int _health = 3;
    public bool _canTakeDamage = true;
    
    public float damageAmount = 1;
    public ParticleSystem bloodParticle;

    void Start()
    {
        
    }

    public IEnumerator TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        

        yield return new WaitForSeconds(1f);
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
            _canTakeDamage = false;
            //BulletAttack bulletAttack = GetComponent<BulletAttack>();
            //StartCoroutine(routine:TakeDamage(bulletAttack.Bulletdamage()));
            bloodParticle.Play();
        }
    
    }
    public void Update()
     {
        if(_health <= 0)
        {
            this.gameObject.SetActive(false);
        }
     }}
