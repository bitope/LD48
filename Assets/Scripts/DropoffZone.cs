using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropoffZone : MonoBehaviour
{
    public float tick = 5f;

    SubController sb;
    void Start()
    {
        sb = GameObject.Find("Submarine").GetComponent<SubController>();
    }

    // Update is called once per frame
    void Update()
    {
        tick -= Time.deltaTime;
        if (tick < 0)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rb = collision.attachedRigidbody;
        if (rb.gameObject.tag == "PickupSub")
        {
            rb.gameObject.tag = "Done";
            Debug.Log("Score!");
            Destroy(rb.gameObject, 0.5f);
            sb.BroadcastMessage("GainFuel", 2000f);
        }
    }
}
