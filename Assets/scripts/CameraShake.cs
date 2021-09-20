using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform cam;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    [SerializeField]
    float initialDuration; 
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        startPosition = cam.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldShake)
        {
            if(duration>0)
            {
                cam.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                cam.localPosition = startPosition;
            }
        }
        
    }
}
