using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionPortal : MonoBehaviour
{
    public GameObject Player;
    public Transform TP;

    void OnTriggerEnter(Collider other2)
    {
        Player.transform.position = TP.transform.position;
        Player.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
