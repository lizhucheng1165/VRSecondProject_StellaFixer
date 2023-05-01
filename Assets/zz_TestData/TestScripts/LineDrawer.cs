using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    RaycastHit hits;
    List<Transform> stars;

    void Start()
    {
        stars = new List<Transform>();
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            DoRaycast();
        }
    }

    void Drawing()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            if (i == 0)
            {
                try
                {
                    LineRenderer line = stars[i].gameObject.AddComponent<LineRenderer>();
                    line.useWorldSpace = true;
                    line.positionCount = 1;

                    Material mat = new Material(Shader.Find("Standard"));
                    mat.color = new Color(0, 21, 20, 0.8f);
                    line.material = mat;
                    line.startWidth = 0.1f;
                    line.endWidth = 0.1f;
                    line.enabled = true;
                    line.SetPosition(i, stars[i].position);
                }
                catch
                {

                }
            }
            else
            {
                stars[0].GetComponent<LineRenderer>().positionCount = stars.Count;
                stars[0].GetComponent<LineRenderer>().SetPosition(i, stars[i].position);
            }
        }
    }

    void GetStar()
    {
        if (hits.transform != null && hits.transform.CompareTag("StarPoint"))
        {
            if (stars.Count == 0)
            {
                stars.Add(hits.transform);
            }
            else
            {
                if (stars[stars.Count - 1] != hits.transform)
                {
                    stars.Add(hits.transform);
                }
            }
        }
    }

    void DoRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hits, 30f))
        {
            GetStar();
            if (stars.Count != 0)
            {
                Drawing();
            }
        }
    }
}
