using UnityEngine;

public class FallingBlocks : MonoBehaviour
{
    public float speed;
    public Renderer matCol;
    public Color myColor;
    public Vector2 speedMinMax;
    private ObjectPool objPool;
    void Start()
    {
        matCol = GetComponent<Renderer>();
        objPool = FindObjectOfType<ObjectPool>();
    }
    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(speedMinMax.y, speedMinMax.x, Difficulty.GetDifficultyPercent());
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        //matCol.material.color = Color.Lerp(matCol.material.color, myColor, 1.1f * Time.deltaTime);
        if (transform.position.y < (-Camera.main.orthographicSize - (transform.localScale.y / 2f)))
        {
            objPool.ReturnBlock(gameObject);
        }
    }
}
