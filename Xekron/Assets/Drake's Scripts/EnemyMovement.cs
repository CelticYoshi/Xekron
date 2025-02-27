using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 1;
    public AudioClip EnemyHurt;
    public float speed = 1f;
    //public float rangeValue = 5f;
    public float minDistance = 1.5f;
    public float maxDistance = 10f;
    //public float rotationSpeed;
    //private Vector3 _startingPosition;
    private AudioSource _enemySound;
    [SerializeField] private bool _isAttacking;
    //[SerializeField] private Transform _player;
    [SerializeField] private Animator _enemyAnimation;
    //[SerializeField] private Rigidbody _enemyRb;
    private NavMeshAgent navMeshAgent;
    public ParticleSystem bloodParticle;


    // Start is called before the first frame update
    void Start()
    {
        //_startingPosition = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        _enemySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (player != null)
        {
            
            if(distance < minDistance)
            {
                navMeshAgent.isStopped = true;
                _enemyAnimation.SetBool("IsMoving", false);
                _enemyAnimation.SetBool("IsInRange", false);
            }
            if(distance > maxDistance)
            {
                navMeshAgent.isStopped = true;
                _enemyAnimation.SetBool("IsMoving", false);
                _enemyAnimation.SetBool("IsInRange", false);
            }
            else
            {
                
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(player.position);
                _enemyAnimation.SetBool("IsMoving", true);
                _enemyAnimation.SetBool("IsInRange", true);
            } 
        }    
            
            
}
void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("I hit the enemy");
            _enemySound.PlayOneShot(EnemyHurt, 1.0f);
            bloodParticle.Play();
            //Destroy(this.gameObject);
        }
    }
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

