using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform _player;
    public AudioClip EnemyHurt;
    public float speed = 1f;
    //public float rangeValue = 5f;
    public float minDistance = 1.5f;
    public float maxDistance = 10f;
    public float rotationSpeed;
    private Vector3 _startingPosition;
    private AudioSource _enemySound;
    [SerializeField] private bool _isAttacking;
    //[SerializeField] private Transform _player;
    [SerializeField] private Animator _enemyAnimation;
    //[SerializeField] private Rigidbody _enemyRb;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        _enemySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = (_player.position - transform.position).normalized;
        
        float distance = Vector3.Distance(_player.position, transform.position);
        //Debug.Log("Distance" + distance);
        if(distance < maxDistance)
            {
                //_enemyRb.velocity = movementDirection * speed;
                //transform.LookAt(_player);
                navMeshAgent.SetDestination(_player.position);
                 _enemyAnimation.SetBool("IsInRange", true);
            }
            else if (distance > minDistance)
            {
                 _enemyAnimation.SetBool("IsInRange", false);
                 _enemyAnimation.SetBool("IsMoving", false);
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
}
void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("I hit the enemy");
            _enemySound.PlayOneShot(EnemyHurt, 1.0f);
            //Destroy(this.gameObject);

        }}

         public void EnemyAttack()
    {
        _isAttacking = true;
        _enemyAnimation.SetBool("IsMoving", false);
        _enemyAnimation.SetTrigger("IsAttacking");
        StartCoroutine("EnemyAttackCoolDown");
    }

    IEnumerator EnemyAttackCoolDown()
    {
        yield return new WaitForSeconds(3f);
        _isAttacking = false;
    }
}

