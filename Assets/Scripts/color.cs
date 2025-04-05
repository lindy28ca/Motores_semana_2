using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour
{
    private Button Button;
    [SerializeField] private Color color1;
    [SerializeField] private Player player;
    private void Awake()
    {
        Button=GetComponent<Button>();
    }
    private void Start()
    {
        Button.onClick.AddListener(CambiarColor);
    }
    private void CambiarColor()
    {
        if (!player.Damage)
        {
            player.CambiarColor(color1);
        }
    }
}
