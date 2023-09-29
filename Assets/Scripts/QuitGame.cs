using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitGame : MonoBehaviour
{
    public void OnApplicationQuit()
    {
        Application.Quit();
        SceneManager.LoadScene(0);
    }
}
