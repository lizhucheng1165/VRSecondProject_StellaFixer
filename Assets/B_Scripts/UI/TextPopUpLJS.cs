using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TextPopUpLJS : MonoBehaviour
{
    TextMeshProUGUI mission;
    string missionText = "This is mission";

    int TextIndex = 0;
    void Start()
    {
        mission = GetComponent<TextMeshProUGUI>();
        ShowText();
        //mission.text = missionText;
    }

    void Update()
    {
    }

    void ShowText()
    {
        if (TextIndex < missionText.Length)
        {
            mission.text = missionText.Substring(0, TextIndex + 1);
            TextIndex++;
            Invoke("ShowText", 0.25f);
        }
        else return;
    }
}
