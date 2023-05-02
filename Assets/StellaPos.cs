using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StellaPos : MonoBehaviour
{
    public Transform StellaText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("��Ҵ�");
            StellaText.gameObject.SetActive(true);
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RHand))
            {
                print("���ڶ������ �̵�");
                //SceneManager.LoadScene("StellaScene");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("��Ҵ�");
            StellaText.gameObject.SetActive(false);
        }
    }
}
