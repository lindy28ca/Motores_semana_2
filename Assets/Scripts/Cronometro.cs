using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    private float tiempo;
    [SerializeField] TMP_Text text;
    private void Update()
    {
        tiempo += Time.deltaTime;
        text.text = "" + tiempo;
    }
}
