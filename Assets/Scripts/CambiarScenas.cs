using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarScenas : MonoBehaviour
{
    public void Cambiar(string scena)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scena);
    }
    public void Cerrar()
    {
        print("Cerro");
        Application.Quit();
    }
}
