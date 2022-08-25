using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public GameObject cubo;
    public Transform mano;
    public float fuerza;


    private bool activo;
    private bool enmano;
    private Vector3 escala;

    private void Start()
    {

        escala = cubo.transform.localScale;
    }
    void Update()
    {
        if (activo == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                cubo.transform.SetParent(mano);
                cubo.transform.position = mano.position;
                cubo.transform.rotation = mano.rotation;
                cubo.GetComponent<Rigidbody>().isKinematic = true;
                enmano = true;
            }


        }
        if (Input.GetMouseButtonDown(0))
        {
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;

            if (enmano == true)
            {
                cubo.GetComponent<Rigidbody>().AddForce(transform.forward * fuerza, ForceMode.Impulse);
                enmano = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = false;
            cubo.transform.localScale = escala;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            activo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activo = false;
        }
    }

}
