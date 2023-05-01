using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class UIControl_LJS : MonoBehaviour
{
    enum isOnButton
    {
        On,
        NotOn,
        NotButton

    }

    LineRenderer line;
    RaycastHit hits;
    Transform canvas;
    public GameObject title, settings;
    Button button;
    isOnButton OnButton = isOnButton.NotButton;

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        RayCasting();

        //Test
        ChangeColor();

        PopUpText();
        SceneMove();
        OpenSetting();
        CloseSetting();
        ExitPlay();
    }


    void RayCasting()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hits, 30f))
        {
            line.SetPosition(1, new Vector3(0, 0, hits.distance));
            if (hits.transform.GetComponent<Button>() != null)
            {
                OnButton = isOnButton.On;
            }
            else
            {
                OnButton = isOnButton.NotButton;
            }
        }
        else
        {
            line.SetPosition(1, new Vector3(0, 0, 30f));
            OnButton = isOnButton.NotOn;
        }
    }

    void ChangeColor()
    {
        try
        {
            switch (OnButton)
            {
                case isOnButton.On:
                    if (button != null && button != hits.transform.GetComponent<Button>())
                    {
                        button.image.color = Color.white;
                    }
                    button = hits.transform.GetComponent<Button>();
                    button.image.color = Color.red;
                    break;
                case isOnButton.NotOn:
                    if (button != null)
                    {
                        button.image.color = Color.white;
                    }
                    break;
                case isOnButton.NotButton:
                    if (button != null)
                    {
                        button.image.color = Color.white;
                    }
                    break;
            }
        }
        catch
        {

        }

    }

    void PopUpText()
    {
        if (hits.transform != null && hits.transform.CompareTag("Door"))
        {
            canvas = hits.transform.GetChild(0);
            canvas.gameObject.SetActive(true);
        }
        else if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    
    void SceneMove()
    {
        if (hits.transform != null && hits.transform.CompareTag("Start"))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                SceneManager.LoadScene(1);
            }
        }
        
    }

    void OpenSetting()
    {
        if (hits.transform != null && hits.transform.CompareTag("Setting"))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                settings.gameObject.SetActive(true);
                title.gameObject.SetActive(false);

            }
        }
    }

    void CloseSetting()
    {
        if (hits.transform != null && hits.transform.gameObject.name == "ButtonReturnTitle")
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                settings.gameObject.SetActive(false);
                title.gameObject.SetActive(true);

            }
        }
    }
    void ExitPlay()
    {
        if (hits.transform != null && hits.transform.gameObject.name == "ButtonQuit")
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Btn_ExitGame();
            }
        }
    }
    public void Btn_ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
