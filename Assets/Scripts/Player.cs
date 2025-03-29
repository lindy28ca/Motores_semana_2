using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    [SerializeField] private float Velocidad;
    private float horizontal;

    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rigidbody2.velocity = new Vector2(horizontal * Velocidad, rigidbody2.velocity.y);
    }
}
