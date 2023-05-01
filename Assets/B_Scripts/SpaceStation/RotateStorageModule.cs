using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStorageModule : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float rotSpeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotSpeed, 0, 0) * Time.deltaTime);
    }
}
