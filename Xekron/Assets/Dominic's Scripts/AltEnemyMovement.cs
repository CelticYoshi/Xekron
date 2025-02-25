using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AltEnemyMovement : MonoBehaviour
{
    public AudioClip EnemyHurt;
    public ParticleSystem bloodParticle;
    public float speed = 10f;
    public float minDistance = 1.5f;
    public float maxDistance = 10f;
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Rigidbody _zombieRb;
    private AudioSource _enemySound;
    private GameObject _player;
    [SerializeField] private Animator _enemyAnimation;

    // Start is called before the first frame update
    void Start()
    {
        //_zombieRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (player != null)
        {
            if(distance < maxDistance && distance > minDistance)
            {
                Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
                //_zombieRb.AddForce(lookDirection * speed);
                navMeshAgent.SetDestination(player.position);
                _enemyAnimation.SetBool("IsMoving", true);
                _enemyAnimation.SetBool("IsInRange", true);
            }
            else if(distance < minDistance)
            {
                _enemyAnimation.SetBool("IsInRange", false);
                _enemyAnimation.SetBool("IsMoving", false);
            }
            if(distance > maxDistance)
            {
               _enemyAnimation.SetBool("IsInRange", false);
               _enemyAnimation.SetBool("IsMoving", false); 
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
}
