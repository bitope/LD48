using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public GameObject mainCamera;
    public float speed = 0.01f;
    // Start is called before the first frame update
    public GameObject sub;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position += new Vector3(0, -1 * Time.deltaTime * speed);
        mainCamera.transform.position = mainCamera.transform.position + new Vector3(sub.transform.localPosition.x, sub.transform.localPosition.y, 0);
        sub.transform.localPosition = new Vector3(0,0,sub.transform.localPosition.z);
    }
}
