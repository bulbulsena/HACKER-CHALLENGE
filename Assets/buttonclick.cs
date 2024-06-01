using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonClick : MonoBehaviour
{
    private Animator animator;
    private bool isClicked = false;

    void Start()
    {
      
    }

    public void ButtonAnim()
    {
        GetComponent <Animation>().Play("buttonanimasyon");
    }
}
       

