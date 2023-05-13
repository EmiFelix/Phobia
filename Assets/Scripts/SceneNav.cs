using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNav : MonoBehaviour
{
    [SerializeField] int index;

    public void ChangeScene(int i)
    {
        index = i;
        SceneManager.LoadScene(i);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
