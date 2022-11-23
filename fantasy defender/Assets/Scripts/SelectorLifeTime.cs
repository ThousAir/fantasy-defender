using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorLifeTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime = 5.0f;
    private float spawnTime;
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime + lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
