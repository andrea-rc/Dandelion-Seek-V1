using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reina : MonoBehaviour
{
    public float radio;
    public LayerMask capadelPlayer;
    public Transform player;
    public float velocidad;
    bool estarAlerta;
    bool quietonotemeacerques = true;
    float tiempo = 0;
    float activar = 2;
    int vida = 12;
    public GameObject llave;
    [SerializeField] GameManager gm;
    Animator caminar;

    private void Awake()
    {
        caminar = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        llave.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, radio, capadelPlayer);

        if (estarAlerta == true && quietonotemeacerques == true && Time.time >= tiempo)
        {
            Vector3 posPlayer = (new Vector3(player.position.x, transform.position.y, player.position.z));
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
                llave.SetActive(true);
                
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}


