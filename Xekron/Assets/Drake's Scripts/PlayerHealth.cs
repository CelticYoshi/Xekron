using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int _health = 3;
    public TextMeshProUGUI playerHealthText;

    void Start()
    {
        DisplayPlayerHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
        DisplayPlayerHealth();
    }

    public void DisplayPlayerHealth()
    {
        playerHealthText.text = "HP: " + _health.ToString();
    }

    public int GetPlayerHealth()
    {
        return _health;
    }}
