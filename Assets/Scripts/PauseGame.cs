using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // ��������� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGameOnEsc();
            }
            else
            {
                PauseGameOnEsc();
            }
        }
    }

    void PauseGameOnEsc()
    {
        Time.timeScale = 0f; // ������������� ����� � ����
        isPaused = true;
        Debug.Log("Game Paused");
        // ������������� ����� �������� ������ ����� ��� ��������� ������ ��������
    }

    void ResumeGameOnEsc()
    {
        Time.timeScale = 1f; // ������������ ���������� �����
        isPaused = false;
        Debug.Log("Game Resumed");
        // ������������� ����� ������ ������ �����
    }
}