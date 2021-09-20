using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7f;
    float screenHalfunits;
    float screenWidth;
    public CameraShake camShake;
    public event System.Action OnPlayerDeath;
    Vector3 touchPos;
    Touch touch;
    float inputX;
    float velocity;
    private int score=0;
    private int close_call_score=1;
    public GameObject close_call_text;
    Vector2 close_call_pos;
    public GameObject score_Canvas;
    public int close_call_store=0;
  


    void Start()
    {
        screenHalfunits = Camera.main.aspect * Camera.main.orthographicSize;
        screenWidth = Screen.width;
    }
    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR
          inputX = Input.GetAxisRaw("Horizontal");
          velocity = inputX * speed;
          transform.Translate(Vector2.right * velocity * Time.deltaTime);
        #endif
        // FOR TOUCH CONTROLS
        #if UNITY_ANDROID
          if (Input.touchCount > 0)
          {
            touch = Input.GetTouch(0);
            touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            if (touchPos.x > 0)
            {
                //The User has touched on the right side of the screen
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                //The user hase touched the left side of the screen
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
          }
        #endif

        if (transform.position.x < -screenHalfunits)
        {
            transform.position = new Vector2(screenHalfunits, transform.position.y);
        }
        if (transform.position.x > screenHalfunits)
        {
            transform.position = new Vector2(-screenHalfunits, transform.position.y);
        }

    }
    public int Score
    {
        get=>score;
        
        set
        {
            score = value;
        }
    }
    void OnTriggerEnter2D(Collider2D box)
    {
        if (box.tag == "Box")
        {
           
            Handheld.Vibrate();
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            camShake.shouldShake = true;
            Destroy(gameObject);
        }
        if(box.tag == "CloseCall")
        {
            Vibration.Vibrate(500);
            Score+=close_call_score;
            close_call_store += close_call_score;
            //Debug.Log(Score);
            close_call_pos = new Vector2(-7,180);
            GameObject newTxt =  Instantiate(close_call_text,close_call_pos,Quaternion.identity);
            newTxt.transform.SetParent(score_Canvas.transform, false);
        }
    }
}

//Touch Controls to use afterwards
/*Touch touch = Input.GetTouch(0);
        if (touch.position.x > (screenWidth / 2))
        {
            //The User has touched on the right side of the screen
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            //The user hase touched the left side of the screen
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
*/
