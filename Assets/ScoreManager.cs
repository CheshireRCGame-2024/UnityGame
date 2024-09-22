using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위한 네임스페이스
using UnityEngine.SceneManagement; // 씬 전환을 위한 네임스페이스

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // TextMeshPro 텍스트 필드

    void Start()
    {
        int score = PlayerPrefs.GetInt("playerScore", 0); // 저장된 점수를 가져옴
        scoreText.text = "Score: " + score.ToString(); // 점수를 화면에 표시
    }

    // 버튼 클릭 시 호출될 메서드
    public void ResetScoreAndGoToLoadingScene()
    {
        PlayerPrefs.SetInt("playerScore", 0); // 점수 초기화
        SceneManager.LoadScene("LoadingScene"); // LoadingScene으로 이동
    }
}
