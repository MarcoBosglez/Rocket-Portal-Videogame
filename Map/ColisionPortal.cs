using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPortal : MonoBehaviour
{
    public GameObject Player;
    public float angle;
    public Transform TPN;

    void OnTriggerEnter(Collider other2)
    {
        other2.transform.position = TPN.transform.position;
        other2.transform.Rotate(0.0f, angle, 0.0f);
    }
}
   
