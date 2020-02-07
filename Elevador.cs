using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public GameObject moverPlataforma;

    private void OnTriggerStay(Collider other)
    {
        
        moverPlataforma.transform.position += moverPlataforma.transform.up * Time.deltaTime;
    }
}
