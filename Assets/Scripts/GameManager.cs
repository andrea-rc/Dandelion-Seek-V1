using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  
    [SerializeField] int numEnemies;
    public Text enemiesText;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReducirNumEnemies()
    {
        numEnemies = numEnemies - 1;
        enemiesText.text = "= " + numEnemies;
        if (numEnemies == 0)
        {
            SceneManager.LoadScene ("Jefe");
        }
    }

    public void MuerteReina ()
    {
        SceneManager.LoadScene("Pasarnivel");
    }

    
  
}
