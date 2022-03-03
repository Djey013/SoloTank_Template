using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [SerializeField] public GameObject textAlert;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            
        }

        instance = this;
        
        DontDestroyOnLoad(this);
    }
}
