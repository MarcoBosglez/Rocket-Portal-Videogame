using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    public float speed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 impactVector = Vector3.zero;

    [Header("Ground")]
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    private Vector3 velocity;

    // Health
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    
    void Update()
    {
        if (!isGrounded)
            impactVector = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(20);
        }

        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 12f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 20f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddImpact(float impactForce, Vector3 direction)
    {
        float mass = 1f;
        impactVector *= impactForce * Mathf.Sin(Vector3.Angle(transform.up, direction)) / (0.5f * mass);
        velocity.y += impactForce / mass;
        
    }
}
