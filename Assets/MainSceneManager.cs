using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void StartGame()
    {
        // SampleScene���� ��ȯ
        SceneManager.LoadScene("SampleScene");
    }
}
