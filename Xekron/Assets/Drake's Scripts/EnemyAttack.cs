using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int _enemyDamageAmount = 1;
    [SerializeField] private EnemyMovement _enemymovement;
    [SerializeField] private PlayerHealth _player;



    

     public int Enemydamage()
     {
        return _enemyDamageAmount;
     }
}

