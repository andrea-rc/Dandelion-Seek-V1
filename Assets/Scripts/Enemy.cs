using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float radio;
    public LayerMask capadelPlayer;
    public Transform player;
    public float velocidad;
    bool estarAlerta;
    bool quietonotemeacerques = true;
    float tiempo = 0;
    float activar = 5;
    float toque = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       estarAlerta = Physics.CheckSphere(transform.position, radio, capadelPlayer);

        if(estarAlerta == true && quietonotemeacerques == true && Time.time >= tiempo)
        {
            Vector3 posPlayer = (new Vector3 (player.position.x, transform.position.y, player.position.z));
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, velocidad * Time.deltaTime);

        }

        if (Time.time >= tiempo)
        {
            quietonotemeacerques = true;
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Amaragon"))
        {
            toque--;
            quietonotemeacerques = false;
            tiempo = Time.time + activar;

            if (toque == 0)
                Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
