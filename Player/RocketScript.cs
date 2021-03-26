using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */

    [Header("Projectile Variables")]
    public float velocity;
    public float liveTime;

    [Header("Damage Stats")]
    public int damage = 35;
    public float explosionForce = 15;
    public float blastRadius = 5;

    public GameObject explosion;
    Rigidbody rb;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocity;

        Invoke("Explode", liveTime);
    }
    

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Explode();
        }
        else
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    */
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            Explode();
        }
        else if (other.gameObject.layer == 9)
        {
            // Salto desde el muro Explode()
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    

    public void Explode()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, blastRadius);
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].tag == "Player")
            {
                Player playerMovement = players[i].gameObject.GetComponent<Player>();
                if (playerMovement != null)
                {
                    Debug.Log("Add Impact here");
                    playerMovement.AddImpact(explosionForce, transform.position - players[i].transform.position);
                }
            }
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
