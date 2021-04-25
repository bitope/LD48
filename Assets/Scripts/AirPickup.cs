using UnityEngine;

public class AirPickup : MonoBehaviour
{
    public float amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody != null && collision.attachedRigidbody.name == "Submarine")
        {
            collision.gameObject.BroadcastMessage("GainAir", amount, SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null && collision.rigidbody.name == "Submarine")
        {
            collision.gameObject.BroadcastMessage("GainAir", amount, SendMessageOptions.DontRequireReceiver);

            Destroy(this.gameObject);
        }
    }
}