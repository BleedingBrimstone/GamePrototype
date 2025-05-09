using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Проверяем нажатие ESC
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
        Time.timeScale = 0f; // Останавливаем время в игре
        isPaused = true;
        Debug.Log("Game Paused");
        // Дополнительно можно включить панель паузы или выполнить другие действия
    }

    void ResumeGameOnEsc()
    {
        Time.timeScale = 1f; // Возобновляем нормальное время
        isPaused = false;
        Debug.Log("Game Resumed");
        // Дополнительно можно скрыть панель паузы
    }
}