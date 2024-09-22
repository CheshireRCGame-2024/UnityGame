using UnityEngine;
using TMPro; // TextMeshPro�� ����ϱ� ���� ���ӽ����̽�
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� ���ӽ����̽�

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // TextMeshPro �ؽ�Ʈ �ʵ�

    void Start()
    {
        int score = PlayerPrefs.GetInt("playerScore", 0); // ����� ������ ������
        scoreText.text = "Score: " + score.ToString(); // ������ ȭ�鿡 ǥ��
    }

    // ��ư Ŭ�� �� ȣ��� �޼���
    public void ResetScoreAndGoToLoadingScene()
    {
        PlayerPrefs.SetInt("playerScore", 0); // ���� �ʱ�ȭ
        SceneManager.LoadScene("LoadingScene"); // LoadingScene���� �̵�
    }
}
