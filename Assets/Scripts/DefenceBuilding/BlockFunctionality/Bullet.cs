using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    float dmg;
    bool inUse;
    GameObject target;

    public void SetInUse(bool _inUse) { inUse = _inUse; }
    public void SetTarget(GameObject _target) { target = _target; }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider _col)
    {
        if (_col.tag == "Enemy")
        {
            //_col.GetComponent<Enemy>().SetHealth(col.GetComponent<Enemy>().GetHealth() - dmg);
            gameObject.SetActive(false);
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}