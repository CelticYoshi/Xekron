using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _player;
    // Start is called before the first frame update\

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<PlayerController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y > 0)
        {
            _animator.SetBool(name:"WalkForward", true);
        }
        else
        {
            _animator.SetBool(name:"WalkForward", false);
        }

        if (y < 0)
        {
            _animator.SetBool(name:"WalkBackward", true);
        }
        else
        {
            _animator.SetBool(name:"WalkBackward", false);
        }

        if (x > 0)
        {
            _animator.SetBool(name:"WalkRight", true);
        }
        else
        {
            _animator.SetBool(name:"WalkRight", false);
        }

        if (x < 0)
        {
            _animator.SetBool(name:"WalkLeft", true);
        }
        else
        {
            _animator.SetBool(name:"WalkLeft", false);
        }

        _animator.SetBool("IsJumping", _player.PlayerIsJumping());
    }
    }

