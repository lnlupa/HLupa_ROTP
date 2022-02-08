using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.SceneManagement;
//I was getting errors from using SceneManagement up here, so I switched to the fix Visual Studio recommended
public class startButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //Visual Studio recommended this instead of the original code
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
