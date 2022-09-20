using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instacne;

    private void Awake()
    {
        instacne = this;
    }
    #endregion

    public GameObject player;

    [System.Obsolete]
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();

            Debug.Log("Player Quit the game ");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Application.LoadLevel(0);
        }


    }
}
