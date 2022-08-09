using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoEnemy : MonoBehaviour

{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) ;
        {
            Debug.Log("Dañado");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
