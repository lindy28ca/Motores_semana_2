using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour
{
    [SerializeField] private Button Button1;
    [SerializeField] private Button Button2;

    [SerializeField] private Color color1;
    [SerializeField] private Color color2;

    [SerializeField] private Player player;

    private void Start()
    {
        Button1.onClick.AddListener(CambiarColor1);
        Button2.onClick.AddListener(CambiarColor2);
    }

    private void CambiarColor1()
    {
        player.CambiarColor(color1);
    }
    private void CambiarColor2()
    {
        player.CambiarColor(color2);
    }
}
