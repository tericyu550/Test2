using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    public void Gamestart()
    {
        SceneManager.LoadScene("SceneFirst");
    }
}
