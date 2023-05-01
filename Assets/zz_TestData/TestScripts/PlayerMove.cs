using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float moveSpeed, rotSpeed;
    void Start()
    {
        moveSpeed = 10f;
        rotSpeed = 5f;
    }

    void Update()
    {
        CharMove();
    }

    void CharMove()
    {
        Vector3 movDir = new Vector3(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).x, 0, OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).y);
        OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
        
        this.transform.Translate(movDir * Time.deltaTime * moveSpeed);

        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x != 0)
        {
            this.transform.Rotate(Vector3.up * rotSpeed * OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch).x) ;
        }
    }
}
