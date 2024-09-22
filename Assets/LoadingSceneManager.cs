using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingSceneManager : MonoBehaviour
{
    public string nextSceneName;  // �ε��� ���� ���� �̸�
    public Slider progressBar;    // �ε� ���൵�� ǥ���� ProgressBar (���û���)

    void Start()
    {
        // Debug �α׿� UnityEngine.Debug�� ��������� ���
        if (progressBar != null)
        {
            UnityEngine.Debug.Log("Progress Bar �����!");
        }
        else
        {
            UnityEngine.Debug.Log("Progress Bar�� ������� �ʾҽ��ϴ�.");
        }

        // �ε� ����
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        // UnityEngine.AsyncOperation�� ��������� ���
        UnityEngine.AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);

        // �ε��� �Ϸ�� ������ ��ٸ�
        while (!operation.isDone)
        {
            // �ε� ���൵�� ProgressBar�� ǥ�� (0 ~ 1 ����)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progressBar != null)
            {
                progressBar.value = progress;
            }

            yield return null;  // ���� �����ӱ��� ��ٸ�
        }
    }
}
