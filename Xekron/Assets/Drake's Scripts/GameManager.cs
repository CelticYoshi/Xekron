using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int _enemyAmount;
    public int _collectableAmount;
     public TextMeshProUGUI enemyText;
     public TextMeshProUGUI collectableText; 
     public GameObject tractor;
     public bool tractorIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        _enemyAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyText.text = "Enemies Remaining: " + _enemyAmount.ToString();
        
        _collectableAmount = GameObject.FindGameObjectsWithTag("Collectable").Length;
        collectableText.text = "Collectables Remaining: " + _collectableAmount.ToString();
        tractorIsActive = false;
    }
    public void UpdateCollectableAmount()
    {
        _collectableAmount -= 1;
        collectableText.text = "Collectables Remaining: " + _collectableAmount.ToString();
        if(_collectableAmount <= 0)
        {
            
            GameObject.Find("GameManager").GetComponent<GameOverConditions>().NoMoreCollectables();
        }
        
    }
    // Update is called once per frame
    
    public void UpdateEnemyAmount()
    {
        _enemyAmount -= 1;
        enemyText.text = "Enemies Remaining: " + _enemyAmount.ToString();
        if(_enemyAmount <= 0)
        {
            
            GameObject.Find("GameManager").GetComponent<GameOverConditions>().NoMoreEnemies();
        }
    
    }
}
