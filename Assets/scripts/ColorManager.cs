using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorManager : MonoBehaviour
{
    public Color[] myColors;
    int colorIndex = 0;
    [SerializeField] [Range(0f, 1f)] float lerpTime;
    float t = 0f;
    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        cam.backgroundColor = Color.Lerp(cam.backgroundColor, myColors[colorIndex], lerpTime * Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime * Time.deltaTime);
        if (t > 0.9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= myColors.Length) ? 0 : colorIndex;
        }

    }
}
