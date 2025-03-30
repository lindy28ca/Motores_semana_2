using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    private float tiempo;
    [SerializeField] TMP_Text text;

    [SerializeField] TMP_Text ganaste;
    [SerializeField] TMP_Text perdiste;
    private void Update()
    {
        if (Time.timeScale == 0)
        {
            ganaste.text = "" + tiempo;
            perdiste.text = "" + tiempo;
        }
        tiempo += Time.deltaTime;
        text.text = "" + tiempo;
    }
}
