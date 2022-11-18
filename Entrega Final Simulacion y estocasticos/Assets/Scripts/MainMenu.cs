using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNow()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Level -1");

    }
}
