using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int _health = 3;
    public bool _canTakeDamage = true;
    public TextMeshProUGUI playerHealthText;

    void Start()
    {
        DisplayPlayerHealth();
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
            
        }
     }
    
    }
