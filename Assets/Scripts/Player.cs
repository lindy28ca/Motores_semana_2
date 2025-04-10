using System;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rigidbody2;
    [SerializeField] private float Velocidad;
    private float horizontal;
    [SerializeField] private float distancia;

    [SerializeField] private float FuerzaSalto;
    private bool salto;
    [SerializeField] private LayerMask layer;
    private bool dobleSalto;

    [SerializeField] private float vida;

    public static event Action Perdiste;
    public static event Action Ganaste;
    public static event Action Puntos;
    public static event Action Corazones;
    public static event Action<float> Vida;

    private bool damage;
    public bool Damage => damage;
    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Vida?.Invoke(vida);
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
        }
        if (vida <= 0)
        {
            Perdiste?.Invoke();
        }
        if (damage)
        {
            vida -= Time.deltaTime;
            Vida?.Invoke(vida);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limite"))
        {
            Perdiste?.Invoke();
        }
        if (collision.gameObject.CompareTag("Ganaste"))
        {
            Ganaste?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moneda"))
        {
            Puntos?.Invoke();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Corazon"))
        {
            ++vida;
            Vida?.Invoke(vida);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Color") && !ComprobarColor(collision.gameObject.GetComponent<SpriteRenderer>().color))
        {
            damage = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Color"))
        {
            damage = false;
        }
    }
    private bool ComprobarColor(Color color)
    {
        return sr.color == color;
    }
}
