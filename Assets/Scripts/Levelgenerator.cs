using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelgenerator : MonoBehaviour
{
    public Camera mainCamera;

    public GameObject[] terrainPrefabs;
    public GameObject[] fishPrefabs;
    public GameObject[] bubblePrefabs;

    public float yDistance = 0.1f;

    float bubbleCooldown;

    void Start()
    {
        var pos = -5f;
        for (int i = 0; i < 100; i++)
        {
            pos += UnityEngine.Random.Range(-1f, 1f);
            var goL = Instantiate(terrainPrefabs[0], new Vector3(pos, -i * yDistance), Quaternion.identity);
            goL.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
            var goR = Instantiate(terrainPrefabs[0], new Vector3(pos+UnityEngine.Random.Range(7f,9f) , -i * yDistance), Quaternion.identity);

            var f = Instantiate(fishPrefabs[0], new Vector3(pos + UnityEngine.Random.Range(0f, 9f), -i * yDistance), Quaternion.identity);
            f.transform.localScale = Vector3.one * Random.Range(0.5f, 3f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        bubbleCooldown -= Time.deltaTime;
        
        var r = Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);
        if (bubbleCooldown<0)
        {
            var p = new Vector2(mainCamera.transform.position.x+r,mainCamera.transform.position.y-20);
            bubbleCooldown = 3f;
            var b = Instantiate(bubblePrefabs[0],p,Quaternion.identity);
            Destroy(b, 30f);
        }
    }
}
