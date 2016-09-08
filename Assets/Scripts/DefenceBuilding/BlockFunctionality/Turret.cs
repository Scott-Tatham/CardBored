using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : BaseBlock
{
    [SerializeField]
    int poolSize;
    [SerializeField]
    float radius;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    GameObject firePoint;
    bool canDo;
    int index;
    GameObject target;
    GameObject[] bullets;
    List<GameObject> enemies = new List<GameObject>();

    public void RemoveEnemies(GameObject _enemy)
    {
        enemies.Remove(_enemy);
    }

    void Start()
    {
        bullets = new GameObject[poolSize];
        Refill();
        canDo = true;
        index = 0;
    }

    protected override void Update()
    {
        base.Update();

        if (et.GetCanDo())
        {
            if (canDo)
            {
                canDo = false;
                Detect();

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (LineOfSight(enemies[i]))
                    {
                        target = enemies[i];
                        Shoot();
                        break;
                    }
                }
            }
        }

        if (!et.GetCanDo() && !canDo)
        {
            canDo = true;
        }
    }

    void Detect()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in cols)
        {
            if (!enemies.Contains(col.gameObject))
                {
                if (col.tag == "Enemy")
                {
                    enemies.Add(col.gameObject);
                }
            }
        }
    }

    bool LineOfSight(GameObject _enemy)
    {
        RaycastHit[] hits;
        Vector3 enemyNorm = (transform.position - _enemy.transform.position).normalized;

        hits = Physics.RaycastAll(transform.position, enemyNorm, radius);
        Debug.DrawRay(transform.position, enemyNorm, Color.green, 1.0f);

        Debug.Log(hits.Length);
        foreach (RaycastHit hit in hits)
        {
            Debug.Log("Here");
            if (hit.transform.tag == "Enemy")
            {
                return true;
            }
        }

        return false;
    }

    void Shoot()
    {
        firePoint.transform.LookAt(target.transform);

        if (bullets[index] != null)
        {
            GameObject currentbullet = bullets[index];
            currentbullet.transform.position = firePoint.transform.position;
            currentbullet.SetActive(true);
            currentbullet.GetComponent<Bullet>().SetInUse(true);
            currentbullet.GetComponent<Bullet>().SetTarget(target);
            index++;
        }

        else
        {
            Refill();

            if (index == bullets.Length - 1)
            {
                index = 0;
            }

            else
            {
                index++;
            }

            Invoke("Shoot", 0);
        }
    }

    void Refill()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (bullets[i] == null)
            {
                bullets[i] = Instantiate(bulletPrefab);
            }
        }
    }
}