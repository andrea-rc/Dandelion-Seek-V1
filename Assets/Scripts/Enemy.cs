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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       estarAlerta = Physics.CheckSphere(transform.position, radio, capadelPlayer);

        if(estarAlerta == true)
        {
            Vector3 posPlayer = (new Vector3 (player.position.x, transform.position.y, player.position.z));
            transform.LookAt(posPlayer);
            transform.position = Vector3.MoveTowards(transform.position, posPlayer, velocidad * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
