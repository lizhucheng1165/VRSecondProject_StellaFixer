using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMaker : MonoBehaviour
{
    BoxCollider boxCollider;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        rectTransform = GetComponent<RectTransform>();
        boxCollider.size = rectTransform.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
