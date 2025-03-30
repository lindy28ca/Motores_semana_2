using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] private float Vida;

    [SerializeField] private Image barradevida;

    [SerializeField] private GameObject ganaste;
    [SerializeField] private GameObject perdiste;
    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        barradevida.fillAmount =(float) Vida / 10;
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto = true;
        }
        if (Vida <= 0)
        {
            perdiste.SetActive(true);
            Time.timeScale = 0;
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
            perdiste.SetActive(true);
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Ganaste"))
        {
            ganaste.SetActive(true);
            Time.timeScale = 0;
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Color"))
        {
            Vida-=Time.deltaTime;
        }
    }
}
