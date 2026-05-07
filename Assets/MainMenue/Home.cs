using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}