using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public static void RestartMyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
