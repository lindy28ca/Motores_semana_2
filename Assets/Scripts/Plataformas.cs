using UnityEngine;

public class Plataformas : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void ConfirmarColor(Color color)
    {
        if (color == sr.color)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
    }
    private void OnEnable()
    {
        GameManager.parartiempo += ConfirmarColor;
    }
    private void OnDisable()
    {
        GameManager.parartiempo += ConfirmarColor;
    }

}
