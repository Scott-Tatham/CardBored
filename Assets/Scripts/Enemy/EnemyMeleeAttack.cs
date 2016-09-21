using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyMeleeAttack : MonoBehaviour
{
	private Transform player;
    private Transform target;
    public float attackSpeed = 0.0f;
    public int meleeDamage;
    private bool canAttack = true;
    private AIPath aIPath;

    void Start()
    {
		aIPath = GetComponent<AIPath> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    void Update()
    {
		if (target == null) 
		{
			target = aIPath.target;
		}

        float distance = Vector3.Distance(target.position, transform.position);

        if ((distance < 2) && (canAttack == true))
        {
            StartCoroutine("EnemyAttack");
        }
    }

    public IEnumerator EnemyAttack()
    {
        canAttack = false;
        target.GetComponent<BaseBlock>().SetHealth(target.GetComponent<BaseBlock>().GetHealth() - meleeDamage);
        yield return new WaitForSeconds(attackSpeed);
		canAttack = true;

    }
}