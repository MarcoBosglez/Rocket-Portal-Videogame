using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COLLIDE : MonoBehaviour
{
    
    public GameObject BulletTP;
   
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(BulletTP);
    }
}
