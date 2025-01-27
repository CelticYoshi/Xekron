using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rangeValue = 5f;
    private Vector3 _startingPosition;
    [SerializeField] private bool _isAttacking;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _enemyAnimation;
    [SerializeField] private Rigidbody _enemyRb;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = (_player.position - transform.position).normalized;
        
        float distance = Vector3.Distance(_player.position, transform.position);
        //Debug.Log("Distance" + distance);
        if(distance < rangeValue)
            {
                _enemyRb.velocity = movementDirection * speed;
                transform.LookAt(_player);
                navMeshAgent.SetDestination(_player.position);
            }

    
}}
