using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewFPS : MonoBehaviour
{
    public TMP_Text fpsText;
    // Start is called before the first frame update
    void Start()
    {
        fpsText.text = "FPS : ";
    }

    // Update is called once per frame
    void Update()
    {
        fpsText.text = "FPS : " + Math.Round((1 / Time.deltaTime), 0);
    }
}
