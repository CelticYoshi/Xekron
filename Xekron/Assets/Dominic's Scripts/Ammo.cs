using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ammo : MonoBehaviour
{
     public TextMeshProUGUI ammoAmountText;
    public int _ammoAmount = 12;
    public AudioClip loseSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        DisplayAmmoAmount();
        playerAudio = GetComponent<AudioSource>();
    }

    public void RemoveAmmo()
    {
        _ammoAmount -= 1;
        DisplayAmmoAmount();
    }

    public void AddAmmo()
    {
        _ammoAmount = 12;
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
