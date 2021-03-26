using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [Header("Weapon Stats")]
    // Weapon Stats
    private int currentAmmo = 4;
    private int clipAmount;
    public int maxAmmo = 20;

    public float reloadTime = 0.7f;
    private float lastFireTime;

    [Header("Projectile Variables")]
    // Projectile
    public Rigidbody rocket;
    public float rocketSpeed = 50f;

    [Header("Manager & Animator")]
    // Manager & Animator
    public Animator animator;
    private AmmoText gameplayManager;

    [Header("States")]
    // States
    private bool isReloading = false;

    private void Awake()
    {
        gameplayManager = GameObject.FindObjectOfType<AmmoText>();
    }

    private void Start()
    {
        clipAmount = currentAmmo;
    }

    void Update()
    {
        gameplayManager.UpdateAmmo(currentAmmo, maxAmmo);

        if (isReloading)
            return;

        if (currentAmmo == 0) {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != clipAmount)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > (lastFireTime + reloadTime) && currentAmmo > 0)
        {
            currentAmmo--;

            Rigidbody clonedRocket;
            clonedRocket = Instantiate(rocket, transform.position, transform.rotation);

            clonedRocket.velocity = transform.TransformDirection(Vector3.forward * rocketSpeed);
            lastFireTime = Time.time;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        int mun = 4 - currentAmmo;

        currentAmmo = clipAmount;
        maxAmmo -= mun;
        Debug.Log("Max Ammo: " + maxAmmo);
 
        isReloading = false;
    }
}
