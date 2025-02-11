using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _enemyDamageAmount = 1;
    [SerializeField] private EnemyMovement _enemymovement;
    [SerializeField] private PlayerHealth _player;



     void OnControllerColliderHit(ControllerColliderHit hit)
     {
        Debug.Log("I hit the player");
            _enemymovement.EnemyAttack();
            _player.TakeDamage(_enemyDamageAmount);
     }

     public int Enemydamage()
     {
        return _enemyDamageAmount;
     }
}

