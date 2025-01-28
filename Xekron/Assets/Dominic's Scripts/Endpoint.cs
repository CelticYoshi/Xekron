using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    [SerializeField] private bool _hasReached;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _hasReached = true;
        }
    }

    public bool HasReached()
    {
        return _hasReached;
    }
}
