using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject perdiste;
    [SerializeField] private GameObject ganaste;

    [Header("Puntos")]
    [SerializeField] private TMP_Text Textpuntos;
    private float puntos;

    [Header("Botones")]
    [SerializeField] private Color[] colores;
    [SerializeField] private Player player;
    private int contador;

    public static event Action<Color> parartiempo;
    private void Start()
    {
        player.CambiarColor(colores[contador]);
        parartiempo?.Invoke(colores[contador]);
    }
    private void Perdiste()
    {
        perdiste.SetActive(true);
        Time.timeScale = 0;
    }
    private void AgregarPuntos()
    {
        puntos += 5;
        Textpuntos.text = "" + puntos;
    }
    private void Ganaste()
    {
        ganaste.SetActive(true);
        Time.timeScale = 0;
    }
    public void CambiarColor(float direccion)
    {
        if (colores == null || colores.Length == 0 || player == null)
        {
            return;
        }
        if (direccion > 0)
        {
            contador--;
            if (contador < 0)
            {
                contador = colores.Length - 1;
            }
        }
        else if (direccion < 0)
        {
            contador++;
            if (contador >= colores.Length)
            {
                contador = 0;
            }
        }
        player.CambiarColor(colores[contador]);
        parartiempo?.Invoke(colores[contador]);
    }
    private void OnEnable()
    {
        Player.Ganaste += Ganaste;
        Player.Perdiste += Perdiste;
        Player.Puntos += AgregarPuntos;
        InputReader.cambiarColor += CambiarColor;
    }
    private void OnDisable()
    {
        Player.Ganaste -= Ganaste;
        Player.Perdiste -= Perdiste;
        Player.Puntos -= AgregarPuntos;
        InputReader.cambiarColor -= CambiarColor;
    }

}
