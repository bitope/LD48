using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubController : MonoBehaviour
{
    Rigidbody2D rb;
    LineRenderer grappleLine;
    ParticleSystem bubbles;
    // Start is called before the first frame update

    public Transform torpedoMount;
    public GameObject torpedoPrefab;
    public float torpedoCooldown;


    public float maxFuel = 100;
    public float currentFuel;

    public float maxAir = 100;
    public float currentAir;

    void Start()
    {
        bubbles = GetComponentInChildren<ParticleSystem>();
        grappleLine = GetComponent<LineRenderer>();
        grappleLine.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        currentFuel = maxFuel;
        currentAir = maxAir;
        bubbles.Pause();
    }

    Vector2 currentMovement;

    internal float GetFuelRatio()
    {
        return currentFuel / maxFuel;
    }

    internal float GetAirRatio()
    {
        return currentAir / maxAir;
    }

    public void GainFuel(float amount)
    {
        currentFuel = Mathf.Min(currentFuel + amount, maxFuel);
    }

    public void GainAir(float amount)
    {
        currentAir = Mathf.Min(currentAir + amount, maxAir);
    }

    // Update is called once per frame
    void Update()
    {
        torpedoCooldown -= Time.deltaTime;
        currentAir -= Time.deltaTime * 0.1f;

        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        currentMovement = new Vector2(h, v);
        if (rb.velocity.x<0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        if (Input.GetButtonDown("Fire1"))
        {
            FireTorpedo();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Grapple();
        }

        if (grappleJoint)
        {
            grappleLine.enabled = true;
            grappleLine.SetPosition(0, transform.position);
            grappleLine.SetPosition(1, new Vector3(grappleJoint.anchor.x, grappleJoint.anchor.y, 0) + grappleJoint.gameObject.transform.position);
        } else
        {
            grappleLine.enabled = false;
        }
    }

    private void FireTorpedo()
    {
        if (torpedoCooldown < 0)
        {
            torpedoCooldown = 5f;
            var t = Instantiate(torpedoPrefab, torpedoMount.transform.position, Quaternion.identity) as GameObject;
            if (transform.localScale.x < 0)
            {
                t.transform.localScale = t.transform.localScale * -1;
            }
            Destroy(t, 20f);
        }
    }

    private void FixedUpdate()
    {
        if (currentMovement.magnitude > 0 && currentFuel>0)
        {
            bubbles.Play();
            currentFuel -= currentMovement.magnitude * 1.0f;

            rb.AddForce(currentMovement * rb.mass);
        }
        else
        {
            bubbles.Stop(false,ParticleSystemStopBehavior.StopEmitting);
        }
        //if (grappleJoint)
        //    Debug.Log(grappleJoint.reactionForce);
    }

    //void OnJointBreak2D(Joint2D brokenJoint)
    //{
    //    Debug.Log("A joint has just been broken!");
    //    Debug.Log("The broken joint exerted a reaction force of " + brokenJoint.reactionForce);
    //    Debug.Log("The broken joint exerted a reaction torque of " + brokenJoint.reactionTorque);
    //}

    SpringJoint2D grappleJoint;
    public void Grapple()
    {
        if (grappleJoint)
        {
            Destroy(grappleJoint);
            return;
        }

        var p = Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Pickups"));
        Debug.DrawRay(transform.position, Vector3.down, Color.red, 1.0f);
        Debug.Log(p);
        if (p.collider!=null && p.collider.attachedRigidbody!=null)
        {
            var grappleRB = p.collider.attachedRigidbody;

            grappleJoint = grappleRB.gameObject.AddComponent<SpringJoint2D>();
            grappleJoint.autoConfigureConnectedAnchor = false;
            grappleJoint.connectedBody = rb;

            grappleJoint.autoConfigureDistance = false;
            grappleJoint.distance = p.distance;//1.5f;
            grappleJoint.dampingRatio = 0.5f;
            grappleJoint.frequency = 1f;
            grappleJoint.breakForce = 50f;

            grappleJoint.anchor = p.point - new Vector2(grappleRB.transform.position.x, grappleRB.transform.position.y);
            //grappleJoint.connectedAnchor = p.point;
            //grappleJoint.connectedBody = rb;
            //grappleJoint.anchor = p.point;

        }
    }
}
