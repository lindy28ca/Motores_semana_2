using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rigidbody2;
    [SerializeField] private float Velocidad;
    private float horizontal;
    [SerializeField] private float distancia;

    [SerializeField] private float FuerzaSalto;
    private bool salto;
    [SerializeField] private LayerMask layer;
    private bool dobleSalto;

    [SerializeField] private int Vida;
    
    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
        }
    }
    private void FixedUpdate()
    {
        rigidbody2.velocity = new Vector2(horizontal * Velocidad, rigidbody2.velocity.y);
        Debug.DrawRay(transform.position, Vector2.down * distancia, Color.red);
        if (salto)
        {
            if (ComprobarPiso())
            {
                Salto();
                dobleSalto = true;
            }
            else if (dobleSalto)
            {
                Salto();
                dobleSalto = false;
            }
        }
        salto = false;
    }
    private void Salto()
    {
        rigidbody2.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
    }
    private bool ComprobarPiso()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distancia, layer);
    }
    public void CambiarColor(Color color)
    {
        sr.color = color;
    }
}
