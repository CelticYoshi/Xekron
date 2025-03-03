using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public AudioClip EnemyHurt;
    public float moveSpeed = 10f;
    public float lifeTime = 2f;
    private Rigidbody _rigidbody;
    private AudioSource _enemySound;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = transform.forward * moveSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I hit the enemy");
            _enemySound.PlayOneShot(EnemyHurt, 1.0f);
            Destroy(this.gameObject);

        }

        //if bullet hits any object other than the target
        //Destroy(this.gameObject);
    }
}
