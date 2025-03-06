using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverConditions : MonoBehaviour
{
    public bool _noMoreEnemies = false;
    public int _enemyAmount;
    public int _collectableAmount;
    public bool _noMoreCollectables = false;
    public bool _tractorIsActive = false;
    public GameObject tractor;
    // Start is called before the first frame update
    void Start()
    {
        tractor.gameObject.SetActive(false);
        //_enemyAmount = GetComponent<GameManager>()._enemyAmount;
        //_collectableAmount = GetComponent<GameManager>()._collectableAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (_noMoreEnemies && _noMoreCollectables)
        {
            tractor.gameObject.SetActive(true);
        }
    }

    public void NoMoreEnemies()
    {
        _noMoreEnemies = true;
    }

    public void NoMoreCollectables()
    {
        _noMoreCollectables = true;
    }
}
