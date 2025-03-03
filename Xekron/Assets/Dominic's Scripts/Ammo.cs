using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ammo : MonoBehaviour
{
     public TextMeshProUGUI ammoAmountText;
    public int _ammoAmount = 12;

    // Start is called before the first frame update
    void Start()
    {
        DisplayAmmoAmount();
        //playerAudio = GetComponent<AudioSource>();
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

    public void AmmoRunsOut()
    {
        if (_ammoAmount <= 0)
        {
            //playerAudio.PlayOneShot(loseSound, 1.0f);
            StartCoroutine(OutOfAmmo());
        }
    }

    private IEnumerator OutOfAmmo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
