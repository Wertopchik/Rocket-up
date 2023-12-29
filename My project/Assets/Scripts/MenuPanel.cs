using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void ExitGame()
    {
     Application.Quit(); 
    }
}



