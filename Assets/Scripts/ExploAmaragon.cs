using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAmaragon : MonoBehaviour
{

    public float tiempo=1;
    float momentoExplosion = 0;
    bool boom;
    public GameObject prefabExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            momentoExplosion = Time.time + tiempo;
           
            boom = true;
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        //momentoExplosion = Time.time + tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= momentoExplosion && boom == true)
        {
            Explota();

        }

      

    }

    void Explota()
    {
       
        Destroy(gameObject);

        Instantiate(prefabExplosion, transform.position, transform.rotation);
    }
}
