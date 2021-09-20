using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksManager : MonoBehaviour
{
    public GameObject Blocks;
    float nextSpawnTime;
    Vector2 screenHalfUnits;
    public Vector2 secondsSpawnMinMax;
    public Vector2 spawnsizeMinMax;
    public Vector2 spawnAngleMax;
    public ObjectPool objPool;

    float secondsBetweenSpawns;
    float spawnSize;
    float spawnAngle;
    Vector2 spawnPosition;
    GameObject blocksObj;
    Quaternion rot;
    // Start is called before the first frame update
    void Start()
    {
        
        screenHalfUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            secondsBetweenSpawns = Mathf.Lerp(secondsSpawnMinMax.y, secondsSpawnMinMax.x, Difficulty.GetDifficultyPercent());
            spawnSize = Random.Range(spawnsizeMinMax.x, spawnsizeMinMax.y);
            spawnAngle = Random.Range(spawnAngleMax.x, spawnAngleMax.y);
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            spawnPosition = new Vector2(Random.Range(-screenHalfUnits.x, screenHalfUnits.x), screenHalfUnits.y);
            rot = Quaternion.Euler(Vector3.forward*spawnAngle);
            //GameObject blocksObj = (GameObject)Instantiate(Blocks, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            blocksObj = objPool.GetBlock(spawnPosition , rot);
            //blocksObj.transform.position = spawnPosition;
            //blocksObj.transform.rotation = Quaternion.Euler(Vector3.forward*spawnAngle); 
            blocksObj.transform.localScale = Vector2.one * spawnSize;


        }

    }
}
