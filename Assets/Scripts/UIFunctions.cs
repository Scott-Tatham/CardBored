using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UIFunctions : MonoBehaviour {

	public Slider playerHealthSlider; 

	private PlayerHealth playerHealth; 

	void Start()
	{
			playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth> (); 
	}

	void Update()
	{
		updatePlayerHealthSlider ();
	}

	private void updatePlayerHealthSlider()
	{
		playerHealthSlider.value = playerHealth.currentHealth;
	}
}
