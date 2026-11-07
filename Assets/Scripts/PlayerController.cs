using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManagerDependencyInfo gameManager;
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] Transform cameraTransform;

    public float boostForce = 2.0f;
    public float sideBoost = 7f;

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
    }

    private void FixedUpdate()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 movementVector = new Vector2(movementInput * sideBoost, boostForce);
        rigidbody.AddForce(movementVector);

    }
}
