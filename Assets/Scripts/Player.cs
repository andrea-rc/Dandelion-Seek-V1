using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    public void OnTriggerEnter(Collider other)
    {

		if (other.tag == ("Daño"))
        {
			TakeDamage(20);
        }

		if (currentHealth == 0)
        {
			SceneManager.LoadScene("Game Over");
			currentHealth = 100;
        }
	}

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetKeyDown(KeyCode.Space))
		//{
		//	TakeDamage(20);
		//}
    }
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}


	

	
}
