using UnityEngine;
using System.Collections;

public class EnemyMeleeAttack : MonoBehaviour {
	public GameObject target; 
	public float attackSpeed = 0.0f;  
	public int meleeDamage; 
	private bool canAttack = true; 
	//public ParticleSystem playerHit; 

	void Start () {
		target = GameObject.FindWithTag("Player");
	}

	void Update () {
		StartCoroutine ("EnemyAttack");
	}

	public IEnumerator EnemyAttack()
	{
		float distance = Vector3.Distance (target.transform.position, transform.position);

		if ((distance < 1.5) && (canAttack == true))  {
			canAttack = false;
			target.GetComponent<PlayerHealth> ().currentHealth -= meleeDamage;
			//Instantiate(playerHit, target.transform.position, Quaternion.identity);
			yield return new WaitForSeconds(attackSpeed);
			canAttack = true;
		}
	}
}



	/* 
	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<PlayerHealth> ().currentHealth -= meleeDamage;
		}
	} */