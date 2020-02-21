﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public static bool cursorLocked = true;
    public Transform player;
    public Transform cams;
    public float xSens;
    public float ySens;

    private float adjustY;
    private float adjustX;
    public float maxAngle = 60.0f;
    float inputY;
    float inputX;

    private Quaternion camCenter;
    void Start()
    {
        camCenter = cams.localRotation; //set rotation origin for cameras to camCenter
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
        SetX();
        CursorLock();
    }

    void SetY()
    {
        adjustY = ySens;
        inputY = Input.GetAxis("Mouse Y") * adjustY * Time.deltaTime;
        
        Quaternion adj = Quaternion.AngleAxis(inputY, -Vector3.right);
        Quaternion delta = cams.localRotation * adj;

        if(Quaternion.Angle(camCenter, delta) < maxAngle)
        {
            cams.localRotation = delta;
        } 
        else if(cams.localRotation.eulerAngles.x < (360-maxAngle) && cams.localRotation.eulerAngles.x > maxAngle)
        {
            cams.localRotation = Quaternion.Slerp(cams.localRotation, Quaternion.Euler(maxAngle, 0, 0), Time.deltaTime * 4f);
        }
    }

     void SetX()
    {
        adjustX = xSens;
        inputX = Input.GetAxis("Mouse X") * adjustX * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(inputX, Vector3.up);
        Quaternion delta = player.localRotation * adj;
        player.localRotation = delta;
    }

    void CursorLock()
    {
        if(cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;               
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;               
            }     
        }
    }
}
