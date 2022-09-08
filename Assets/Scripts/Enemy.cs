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
    int vida = 2;
    Animator caminar;
    [SerializeField] GameManager gm;


    private void Awake()
    {
        caminar = GetComponent<Animator>();
    }
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
            caminar.SetBool("Idle", false);
            

        }
        else
        {
            caminar.SetBool("Idle", true);
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
            if (vida >= 1)
            {
                vida = vida - 1;
                quietonotemeacerques = false;
                tiempo = Time.time + activar;
            }


            if (vida == 0)
            {
                Destroy(gameObject);
                gm.ReducirNumEnemies();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
