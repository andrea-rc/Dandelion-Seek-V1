using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
       // if (collision.collider.CompareTag("Player"))
    //    {
    //        gm.MuerteReina();
    //    }
           
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.MuerteReina();
        }
    }
  void Update()
    {
        
    }
}
