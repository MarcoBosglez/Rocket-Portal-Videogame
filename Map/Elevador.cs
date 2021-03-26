using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public GameObject plataforma;
    public float elevatorSpeed = 2.1f;

    private void OnTriggerStay(Collider other)
    {
        plataforma.transform.position += plataforma.transform.up * Time.deltaTime * elevatorSpeed;
    }
}

