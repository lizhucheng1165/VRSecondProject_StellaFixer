using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMove : MonoBehaviour
{
    float pos_x, pos_y, pos_z, min_x, max_x;
    public Transform maxPos, minPos;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        pos_x = this.transform.position.x;
        min_x = minPos.transform.position.x;
        pos_y = this.transform.position.y;
        pos_z = this.transform.position.z;
        max_x = maxPos.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        FixPos();
        GameData.soundValue = GetSliderPoint(this.transform.position.x);
        slider.value = GameData.soundValue;
    }

    void FixPos()
    {
        pos_x = this.transform.position.x;
        if (pos_x < min_x)
        {
            pos_x = min_x;
        }
        if (pos_x > max_x)
        {
            pos_x = max_x;
        }
        this.transform.position = new Vector3(pos_x, pos_y, pos_z);
    }

    float GetSliderPoint(float positionx)
    {
        float temp = max_x - min_x;

        return (positionx - min_x) / temp;
    }
}
