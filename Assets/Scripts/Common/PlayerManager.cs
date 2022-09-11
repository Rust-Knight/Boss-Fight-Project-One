using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
