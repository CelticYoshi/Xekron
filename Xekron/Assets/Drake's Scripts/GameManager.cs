using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int _enemyCount;
    public int _collectableCount;
     public TextMeshProUGUI enemyText;
     public TextMeshProUGUI collectableText; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        //_enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        //enemyText = "Enemies Remaining: " + enemyCount.ToString();
        
        //_collectableCount = GameObject.FindGameObjectsWithTag("Collectable").Length;
        //collectableText = "Collectables Remaining: " + collectableCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
