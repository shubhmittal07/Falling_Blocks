using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Blocks;
    [SerializeField]
    private Queue<GameObject> blocksPool = new Queue<GameObject>();
    [SerializeField]
    private int poolStartsize = 5;

    // Start is called before the first frame update//
    void Start()
    {
        for(int i=0;i<poolStartsize;i++)
        {
            GameObject block = Instantiate(Blocks);
            blocksPool.Enqueue(block);
            block.SetActive(false);
        }
    }
    public GameObject GetBlock(Vector3 position,Quaternion rot)
    {
        if(blocksPool.Count>0)
        {
            GameObject block = blocksPool.Dequeue();
            block.SetActive(true);
            block.transform.position = position;
            block.transform.rotation = rot;
            return block;
        }
        else
        {
            GameObject block = Instantiate(Blocks);
            return block;
        }
    }
    public void ReturnBlock(GameObject block)
    {
        blocksPool.Enqueue(block);
        block.SetActive(false);
    }
    
}
