using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    float moveSpeed;
    GameObject target;

    public void SetTarget(GameObject _target) { target = _target; }

    void Awake()
    {
        moveSpeed = 10.0f;
    }

    void Update()
    {
        HitTarget();
    }

    void HitTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.tag != "TurretBlock")
        {
            if (_col.tag == "Enemy")
            {
                //Damage Enemy
            }

            Destroy(gameObject);
        }
    }
}