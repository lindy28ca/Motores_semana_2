using UnityEngine;
using TMPro;
using System.Globalization;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject perdiste;
    [SerializeField] private GameObject ganaste;

    [Header("Puntos")]
    [SerializeField] private TMP_Text Textpuntos;
    private float puntos;

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
    private void OnEnable()
    {
        Player.Ganaste += Ganaste;
        Player.Perdiste += Perdiste;
        Player.Puntos += AgregarPuntos;
    }
    private void OnDisable()
    {
        Player.Ganaste -= Ganaste;
        Player.Perdiste -= Perdiste;
        Player.Puntos -= AgregarPuntos;
    }

}
