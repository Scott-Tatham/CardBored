using UnityEngine;
using System.Collections;

public class BoxHealth : MonoBehaviour 
{
	public int maxHealth = 100;
	public int currentHealth;
	public ParticleSystem CharacterDeath;

	void Start ()
	{
		currentHealth = maxHealth;
	}

	void Update ()
	{
		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}

		if (currentHealth <= 0)
		{
			//restartButton.SetActive(true);
			//quitButton.SetActive (true);
			Vector3 DeathSpawnPoint = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
			//Instantiate(CharacterDeath, DeathSpawnPoint, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	public void Enemydamage(int enemyDamage)
	{
		currentHealth -= enemyDamage;
	}
}

