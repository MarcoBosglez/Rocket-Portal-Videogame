using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBullet : MonoBehaviour
{

    public GameObject BulletTP;
    public GameObject Portal1;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(BulletTP);
        Instantiate(Portal1, this.transform.position, Quaternion.identity);
        
    }
}
