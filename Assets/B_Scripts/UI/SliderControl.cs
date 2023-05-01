using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControl : MonoBehaviour
{
    RaycastHit hits;
    Transform handle;
    void Start()
    {

    }


    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            CheckHits();
        }
        RayCheck();
    }


    bool CheckHits()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hits, 20f))
        {
            if (hits.transform != null)
            {
                handle = hits.transform;
                return true;
            }
        }
        handle = null;
        return false;
    }

    void RayCheck()
    {
        try
        {
            if (handle.name == "Handle")
            {
                handle.SetParent(this.transform);
                if (!OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    handle.SetParent(null);
                }
            }
        }
        catch
        {

        }
    }
}
