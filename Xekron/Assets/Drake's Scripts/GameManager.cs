using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int _enemyAmount;
    public int _collectableAmount;
     public TextMeshProUGUI enemyText;
     public TextMeshProUGUI collectableText; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        _enemyAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyText.text = "Enemies Remaining: " + _enemyAmount.ToString();
        
        _collectableAmount = GameObject.FindGameObjectsWithTag("Collectable").Length;
        collectableText.text = "Collectables Remaining: " + _collectableAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
