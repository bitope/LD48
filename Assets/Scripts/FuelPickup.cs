using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null && collision.rigidbody.name == "Submarine")
        {
            collision.gameObject.BroadcastMessage("GainFuel", 1000f, SendMessageOptions.DontRequireReceiver);

            Destroy(this.gameObject);
        }
    }
}
