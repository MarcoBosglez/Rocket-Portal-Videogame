using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDeath : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(Player);
        }
    }
}
