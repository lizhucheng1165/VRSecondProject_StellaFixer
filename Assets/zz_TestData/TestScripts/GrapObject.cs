using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapObject : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
            {
                other.transform.SetParent(this.transform);
                other.transform.GetComponent<Rigidbody>().isKinematic = true;

            }
            else
            {
                other.transform.SetParent(null);
                other.transform.GetComponent<Rigidbody>().isKinematic = false;

            }
        }
        catch
        {

        }
    }
}
