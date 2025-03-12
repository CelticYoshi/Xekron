using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public int startingScene;

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(startingScene);
    }

    public void OnQuitButtonPressed()
    {
        Debug.Log("I Quit the Game");
        Application.Quit();
    }

}