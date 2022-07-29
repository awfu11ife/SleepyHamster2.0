using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGameObjectOnLoad : MonoBehaviour
{
    private static DontDestroyGameObjectOnLoad instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
