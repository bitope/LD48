using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{
    // Start is called before the first frame update
    public float updateInterval = 5f;
    public float force = 1f;
    float updateMe;
    Rigidbody2D rb;

    Vector3 goLeft;
    Vector3 goRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = Mathf.Max(0.1f,transform.localScale.x);
        goLeft = transform.localScale;
        goRight = transform.localScale * -1;
    }

    // Update is called once per frame
    void Update()
    {
        updateMe -= Time.deltaTime;
        if (rb.velocity.x > 0)
            transform.localScale = goRight;
        else
            transform.localScale = goLeft;
    }
    

    private void FixedUpdate()
    {
        if (updateMe<0)
        {
            updateMe = updateInterval;
            rb.AddForce(Random.insideUnitCircle * rb.mass * force, ForceMode2D.Impulse);
        }
    }
}
