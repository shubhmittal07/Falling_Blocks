using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    float timeStart;
    public TextMeshProUGUI timerText;
    public bool TimerisRunning=true;
    //private WaitForSeconds waitTime = new WaitForSeconds(1); 

    
    // Start is called before the first frame update
    void Start()
    {
        //timerText.text = Time.timeSinceLevelLoad.ToString("F0");
        StartCoroutine(StartTimer());
        Application.targetFrameRate = 100;
    }
    
    IEnumerator StartTimer()
    {
        while(TimerisRunning)
        {
            timerText.text = Time.timeSinceLevelLoad.ToString("F0");
            yield return null;
        }
    }

}
