using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private float xComp;
    private float zComp;
    private Vector3 speedLimit;
    private PlayerStats us;
    private EnvironmentModifiers em;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        us = GetComponent<PlayerStats>();
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnvironmentModifiers>();
    }

    void Update()
    {
        move();
    }

    public void move()
    {
        rb.AddForce(new Vector3(0, (em.GetGravity() * rb.mass), 0), ForceMode.Acceleration);

        xComp = Input.GetAxis("Horizontal");
        zComp = Input.GetAxis("Vertical");

        us.SetDirectionalVelocity(new Vector3(xComp, 0, zComp));
        us.SetDirectionalVelocity(transform.TransformDirection(us.GetDirectionalVelocity()));

        rb.AddForce(us.GetDirectionalVelocity() * us.GetMoveSpeed(), ForceMode.Impulse);

        speedLimit = (us.GetDirectionalVelocity() - rb.velocity);
        speedLimit.x = Mathf.Clamp(speedLimit.x, -us.GetMoveSpeed(), us.GetMoveSpeed());
        speedLimit.z = Mathf.Clamp(speedLimit.z, -us.GetMoveSpeed(), us.GetMoveSpeed());
        speedLimit.y = 0;

        rb.AddForce(speedLimit, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space) && us.GetAppSurface())
        {
            rb.AddForce((Vector3.up) * us.GetJumpSpeed(), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Environment")
        {
            us.SetAppSurface(true);
        }
    }

    void OnCollisionExit()
    {
        us.SetAppSurface(false);
    }
}