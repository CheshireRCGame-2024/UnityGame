using System.Collections;  // IEnumerator�� ����ϱ� ���� ���ӽ����̽� �߰�
using System;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
/* 
// ���� ����



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
        // TCP Ŭ���̾�Ʈ ����
        client = new TcpClient("192.168.137.150", 5000); // Raspberry Pi�� IP �ּҿ� ��Ʈ
        stream = client.GetStream();

        // ���� ��¿� �ؽ�ó ����
        videoTexture = new Texture2D(640, 480, TextureFormat.RGB24, false);

        // GameObject�� Renderer ��������
        meshRenderer = GetComponent<Renderer>();

        // ������ ���� ������ ����
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

            // ȭ�鿡 �ؽ�ó ����
            meshRenderer.material.mainTexture = videoTexture; // Renderer�� Material�� �ؽ�ó �Ҵ�
        }
    }

    void ReceiveData()
    {
        while (true)
        {
            try
            {
                // ������ ũ�� ���� �б�
                byte[] sizeBytes = new byte[sizeof(long)];
                stream.Read(sizeBytes, 0, sizeBytes.Length);
                long dataSize = BitConverter.ToInt64(sizeBytes, 0);

                // ������ �б�
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

                // ���ŵ� �������� ť�� �߰��Ͽ� ���� �����忡�� ó���ϵ��� ��
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
        // ���� �� ���ҽ� ����
        if (receiveThread != null)
        {
            receiveThread.Abort();
        }
        stream.Close();
        client.Close();
    }
}

*/

// 3�� �Ŀ� ScoreScene���� �̵��ϴ� ����

public class VideoStreamReceiver : MonoBehaviour
{
    void Start()
    {
        int score = 80; // ���� ����
        PlayerPrefs.SetInt("playerScore", score); // ������ PlayerPrefs�� ����
        StartCoroutine(GoToScoreSceneAfterDelay());
    }

    IEnumerator GoToScoreSceneAfterDelay()
    {
        yield return new WaitForSeconds(3f); // 3�� ���
        SceneManager.LoadScene("ScoreScene"); // ScoreScene���� ��ȯ
    }
}
