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
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            other.transform.SetParent(this.transform);
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            //float x = other.transform.parent.rotation.x;
            //float y = other.transform.parent.rotation.y + Vector3.Angle(other.transform.position, this.transform.position)/ 10;
            //float z = other.transform.parent.rotation.z;

            //other.transform.parent.rotation = Quaternion.Euler(x, Mathf.Clamp(y,0,-120f ), z);
        }
        else
        {
            other.transform.SetParent(null);
            other.transform.GetComponent<Rigidbody>().isKinematic = false;

        }
    }
}
