using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class quit_reload : MonoBehaviour
{
    public void _Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void _Quit()
    {
        Application.Quit();
    }

}
