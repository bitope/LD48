using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAI : MonoBehaviour
{
    Vector3 startPos;
    // Start is called before the first frame update
    float seed;
    float xtime;
    void Start()
    {
        startPos = transform.position;
        seed = (float)(UnityEngine.Random.value*Math.PI);
        xtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var o = new Vector3(Mathf.Sin(Time.time+seed), (Time.time-xtime)*0.5f, 0.0f);
        transform.position = startPos + o;
        if (Time.time - xtime > 60f)
        {
            Destroy(this.gameObject);
        }
    }
}
