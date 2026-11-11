using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameMangager;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float maxBoost;

    [SerializeField] AudioSource deathSound;


    public float boostForce = 10f;
    public float sideBoost = 12f;



    // float movementInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //rigidbody.linearVelocity = new Vector2(0, boostForce);
        //Debug.Log(boostForce);
        //Debug.Log(rigidbody.linearVelocityY);
    }

    private void FixedUpdate()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 movementVector = new Vector2(movementInput * sideBoost, 0f);
        Vector2 boostVector = new Vector2(0f, boostForce);

        if(rigidbody.linearVelocityY > maxBoost)
        {
            rigidbody.linearVelocityY = maxBoost;
        }

        Vector2 r2d2Vector = new Vector2(movementVector.x, boostVector.y);
        rigidbody.AddForce(r2d2Vector);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Enemy>() != null)
        {
            Die();
            
        }
    }


    void Die()
    {
        rigidbody.gravityScale = 2f;
        rigidbody.freezeRotation = false;

        rigidbody.AddTorque(50f);
        deathSound.Play();
        gameMangager.Playerdied();
    }

}
