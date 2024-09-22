using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public string nextSceneName;  // 로드할 다음 씬의 이름
    public Slider progressBar;    // 로딩 진행도를 표시할 ProgressBar (선택사항)

    void Start()
    {
        // Debug 로그에 UnityEngine.Debug를 명시적으로 사용
        if (progressBar != null)
        {
            UnityEngine.Debug.Log("Progress Bar 연결됨!");
        }
        else
        {
            UnityEngine.Debug.Log("Progress Bar가 연결되지 않았습니다.");
        }

        // 로딩 시작
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // UnityEngine.AsyncOperation을 명시적으로 사용
        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);

        // 로딩이 완료될 때까지 기다림
        while (!operation.isDone)
        {
            // 로딩 진행도를 ProgressBar에 표시 (0 ~ 1 범위)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progressBar != null)
            {
                progressBar.value = progress;
            }

            yield return null;  // 다음 프레임까지 기다림
        }
    }
}
