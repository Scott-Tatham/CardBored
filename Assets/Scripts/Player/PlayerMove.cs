using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    private float xComp;
    private float zComp;
    private Vector3 speedLimit;
    private EnvironmentModifiers em;

    void Start()
    {
        em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnvironmentModifiers>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, (em.GetGravity() * GetComponent<Rigidbody>().mass), 0), ForceMode.Acceleration);

        xComp = Input.GetAxis("Horizontal");
        zComp = Input.GetAxis("Vertical");

        GetComponent<PlayerStats>().SetDirectionalVelocity(new Vector3(xComp, 0, zComp).normalized);
        GetComponent<PlayerStats>().SetDirectionalVelocity(transform.TransformDirection(GetComponent<PlayerStats>().GetDirectionalVelocity()));

        GetComponent<Rigidbody>().AddForce(GetComponent<PlayerStats>().GetDirectionalVelocity() * GetComponent<PlayerStats>().GetMoveSpeed(), ForceMode.Impulse);

        speedLimit = (GetComponent<PlayerStats>().GetDirectionalVelocity() - GetComponent<Rigidbody>().velocity);
        speedLimit.x = Mathf.Clamp(speedLimit.x, -GetComponent<PlayerStats>().GetMoveSpeed(), GetComponent<PlayerStats>().GetMoveSpeed());
        speedLimit.z = Mathf.Clamp(speedLimit.z, -GetComponent<PlayerStats>().GetMoveSpeed(), GetComponent<PlayerStats>().GetMoveSpeed());
        speedLimit.y = 0;

        GetComponent<Rigidbody>().AddForce(speedLimit, ForceMode.VelocityChange);

        if (Input.GetKeyDown(KeyCode.Space) && GetComponent<PlayerStats>().GetAppSurface())
        {
            GetComponent<Rigidbody>().AddForce((Vector3.up) * GetComponent<PlayerStats>().GetJumpSpeed(), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision _col)
    {
        if (_col.transform.tag == "Environment" || _col.transform.tag == "Block")
        {
            GetComponent<PlayerStats>().SetAppSurface(true);
        }
    }

    void OnCollisionExit()
    {
        GetComponent<PlayerStats>().SetAppSurface(false);
    }
}