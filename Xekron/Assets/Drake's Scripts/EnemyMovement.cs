using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rangeValue = 5f;
    public float rotationSpeed;
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
        _enemyAnimation.SetBool("IsMoving", false);

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
                 _enemyAnimation.SetBool("IsInRange", true);
            }
            else
            {
                 _enemyAnimation.SetBool("IsInRange", false);
            }
         if (movementDirection != Vector3.zero)
        {
            _enemyAnimation.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            _enemyAnimation.SetBool("IsMoving", false);
        }
        

    
}}
