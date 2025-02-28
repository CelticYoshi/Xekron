using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
     public TextMeshProUGUI ammoAmountText;
    private int _ammoAmount = 12;

    // Start is called before the first frame update
    void Start()
    {
        DisplayAmmoAmount();
    }

    public void RemoveAmmo()
    {
        _ammoAmount -= 1;
        ammoAmountText.text = _ammoAmount.ToString();
    }

    public void AddAmmo()
    {
        _ammoAmount += 12;
        DisplayAmmoAmount();
    }

    public int GetAmmoAmount()
    {
        return _ammoAmount;
    }

    public void DisplayAmmoAmount()
    {
        ammoAmountText.text = "Ammo: " + _ammoAmount.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
