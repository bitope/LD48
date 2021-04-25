using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Doorway connectedDoor;

    private List<Collider2D> currentColliders = new List<Collider2D>();

    //private void OnEnable()
    //{
        
    //}

    //private void OnDisable()
    //{
        
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        currentColliders.Add(collision);
        connectedDoor.OpenDoor();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentColliders.Remove(collision);
        if (currentColliders.Count < 1)
        {
            connectedDoor.CloseDoor();
        }
    }
}
