using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultMenu : MonoBehaviour
{
    public void tryAgain()
    {
        SceneManager.LoadScene("Scene_1");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
