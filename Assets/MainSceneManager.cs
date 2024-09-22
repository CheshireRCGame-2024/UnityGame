using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        // SampleScene으로 전환
        SceneManager.LoadScene("SampleScene");
    }
}
