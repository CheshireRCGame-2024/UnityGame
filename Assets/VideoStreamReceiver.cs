using System.Collections;  // IEnumerator를 사용하기 위한 네임스페이스 추가
using System;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/* 
// 기존 내용



public class VideoStreamReceiver : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private Thread receiveThread;
    private Texture2D videoTexture;
    private Renderer meshRenderer;

    private Queue<byte[]> frameQueue = new Queue<byte[]>();

    void Start()
    {
        // TCP 클라이언트 설정
        client = new TcpClient("192.168.137.150", 5000); // Raspberry Pi의 IP 주소와 포트
        stream = client.GetStream();

        // 비디오 출력용 텍스처 설정
        videoTexture = new Texture2D(640, 480, TextureFormat.RGB24, false);

        // GameObject의 Renderer 가져오기
        meshRenderer = GetComponent<Renderer>();

        // 데이터 수신 스레드 시작
        receiveThread = new Thread(ReceiveData);
        receiveThread.Start();
    }

    void Update()
    {
        if (frameQueue.Count > 0)
        {
            byte[] imageData = frameQueue.Dequeue();
            videoTexture.LoadImage(imageData);
            videoTexture.Apply();

            // 화면에 텍스처 적용
            meshRenderer.material.mainTexture = videoTexture; // Renderer의 Material에 텍스처 할당
        }
    }

    void ReceiveData()
    {
        while (true)
        {
            try
            {
                // 프레임 크기 먼저 읽기
                byte[] sizeBytes = new byte[sizeof(long)];
                stream.Read(sizeBytes, 0, sizeBytes.Length);
                long dataSize = BitConverter.ToInt64(sizeBytes, 0);

                // 데이터 읽기
                byte[] data = new byte[dataSize];
                int totalBytesRead = 0;
                while (totalBytesRead < dataSize)
                {
                    int bytesRead = stream.Read(data, totalBytesRead, (int)(dataSize - totalBytesRead));
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    totalBytesRead += bytesRead;
                }

                // 수신된 프레임을 큐에 추가하여 메인 스레드에서 처리하도록 함
                lock (frameQueue)
                {
                    frameQueue.Enqueue(data);
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error receiving data: " + e.Message);
                break;
            }
        }
    }

    void OnApplicationQuit()
    {
        // 종료 시 리소스 해제
        if (receiveThread != null)
        {
            receiveThread.Abort();
        }
        stream.Close();
        client.Close();
    }
}

*/

// 3초 후에 ScoreScene으로 이동하는 로직

public class VideoStreamReceiver : MonoBehaviour
{
    void Start()
    {
        int score = 80; // 점수 선언
        PlayerPrefs.SetInt("playerScore", score); // 점수를 PlayerPrefs에 저장
        StartCoroutine(GoToScoreSceneAfterDelay());
    }

    IEnumerator GoToScoreSceneAfterDelay()
    {
        yield return new WaitForSeconds(3f); // 3초 대기
        SceneManager.LoadScene("ScoreScene"); // ScoreScene으로 전환
    }
}
