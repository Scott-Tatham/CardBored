using UnityEngine;
using System.Collections;

public class Turret : BaseBlock
{
    [SerializeField]
    GameObject bulletP;
    [SerializeField]
    GameObject fireP;
    float radius;
    Collider[] cols;

    void Start()
    {
        radius = 10.0f;
    }

    protected override void Update()
    {
        base.Update();

        FindEnemies();

        if (et.GetCanDo() && et.GetToggle())
        {
            Attack();
        }
    }

    void FindEnemies()
    {
        cols = Physics.OverlapSphere(transform.position, radius);
    }

    void Attack()
    {
        if (cols != null)
        {
            foreach (Collider col in cols)
            {
                if (col.tag == "Player")
                {
                    fireP.transform.LookAt(col.transform);
                    GameObject bullet = Instantiate(bulletP, fireP.transform.position, Quaternion.identity) as GameObject;
                    bullet.GetComponent<Bullet>().SetTarget(col.gameObject);
                }
            }
        }

        et.SetToggle(false);
    }
}