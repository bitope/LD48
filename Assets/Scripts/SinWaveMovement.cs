using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveMovement : MonoBehaviour
{

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var o = new Vector3(0, Mathf.Sin(Time.time), 0.0f);
        transform.localPosition = offset + o;

    }
}
