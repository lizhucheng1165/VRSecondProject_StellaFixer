using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DoorState : MonoBehaviour
{
    public Transform TargetObject;
    
    public float speed = 0.05f; // 이동 속도


    private bool isOn;

    private Vector3 startPos;
    private Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        startPos = TargetObject.position;
        endPos = TargetObject.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            float distance = Vector3.Distance(endPos, TargetObject.position);

            if (distance > 0f) // 일정 거리 이상 남았을 경우
            {
                // 이동
                Vector3 newPosition = Vector3.Slerp(TargetObject.position, endPos, speed * Time.deltaTime);
                TargetObject.position = newPosition;
            } 
    } 
        else
        {
            float distance = Vector3.Distance(TargetObject.position, startPos);

            if (distance > 0f) // 일정 거리 이상 남았을 경우
            {
                // 이동
                Vector3 newPosition = Vector3.Slerp(TargetObject.position, startPos, speed * Time.deltaTime);
                TargetObject.position = newPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOn = true;
            endPos = startPos - new Vector3(1.2f, 0, 0);
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOn = false;
        }
        
    }
}
