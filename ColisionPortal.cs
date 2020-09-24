using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPortal : MonoBehaviour
{
    public GameObject Player;
    public Transform TPN;

    void OnTriggerEnter(Collider other2)
    {
        Player.transform.position = TPN.transform.position;
        Player.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
   
