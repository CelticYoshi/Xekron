using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    float countdown = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            
            if(countdown > 0)
            {
                Debug.Log ("Pressing the escape key" + countdown);
                countdown -= Time.deltaTime;

                if(countdown <= 0)
                {
                    Debug.Log ("Exiting the game");
                    Application.Quit();
                }
            }
            
            
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            countdown = 3;
        }
    }

    
}
