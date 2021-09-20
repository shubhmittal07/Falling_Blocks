using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Player player;
    private int holder_time=0;
    private bool willInc=false;
    private int timeScore;
    int increment=50;
    int min_value=0;
    int max_value=50;
    // Update is called once per frame
    void Update()
    {
        timeScore = (int)Time.timeSinceLevelLoad/50;//BONUS POINTS WHEN PLAYER REACHES 50 OR ABOVE
        if((int)Time.timeSinceLevelLoad==max_value)
        {
            max_value+=increment;
            player.Score += timeScore*10;
        }
        

        
    }
}
