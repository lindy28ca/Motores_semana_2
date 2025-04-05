using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    private Image barradevida;
    private void Awake()
    {
        barradevida = GetComponent<Image>();
    }
    private void ActualizarVida(float vida)
    {
        barradevida.fillAmount = vida / 10;
    }
    private void OnEnable()
    {
        Player.Vida += ActualizarVida;
    }
    private void OnDisable()
    {
        Player.Vida -= ActualizarVida;
    }
}
