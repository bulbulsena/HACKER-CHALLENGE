using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    DontDestroyOnLoad(this.gameObject);
    }
}
