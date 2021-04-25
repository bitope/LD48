using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 2f;

    public void Boom()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            //colliders[i].
        }

        Debug.Log("Boom.");
        Destroy(this.gameObject, 0.2f);
    }
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
