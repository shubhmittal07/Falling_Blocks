using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class blockReturn : MonoBehaviour
{
    private ObjectPool _objPool;
    private void Start()
    {
        _objPool = FindObjectOfType<ObjectPool>();
    }
    
    private void OnDisable()
    {
        if(_objPool != null)
        {
            _objPool.ReturnBlock(this.gameObject);
        }
    }
}
