using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{   
    
    [SerializeField] private int _bulletDamageAmount = 1;
    [SerializeField] private EnemyMovement _enemymovement;
    [SerializeField] private EnemyHealth _enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int Bulletdamage()
     {
        return _bulletDamageAmount;
     }
}
