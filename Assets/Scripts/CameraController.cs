using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
   public Camera Menucam ;
    public Camera AddQuestionCamera ;

     void Start()
    {
        Menucam.enabled = true;
        AddQuestionCamera.enabled = false;
    }

    public void ChangeCamera()
    {
        Menucam.enabled = false;
        AddQuestionCamera.enabled = true;
    }
    public void ChangeToMenu()
    {
        Menucam.enabled = true;
        AddQuestionCamera.enabled = false;
    }
}
