using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
        //targetText.text = "Enemies Remaining: " + _enemyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
