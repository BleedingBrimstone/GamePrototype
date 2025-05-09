using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("Настройки")]
    [SerializeField] private GameObject uiElement; // UI-элемент для переключения
    [SerializeField] private bool pauseGame = true; // Нужна ли пауза при открытии UI?
    [SerializeField] private KeyCode toggleKey = KeyCode.Tab; // Клавиша для переключения

    private bool isUIOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleUI();
        }
    }

    // Метод для переключения UI и паузы
    public void ToggleUI()
    {
        isUIOpen = !isUIOpen;

        // Переключаем UI
        if (uiElement != null)
        {
            uiElement.SetActive(isUIOpen);
        }

        // Ставим/снимаем паузу
        if (pauseGame)
        {
            Time.timeScale = isUIOpen ? 0f : 1f; // 0 - пауза, 1 - нормальная скорость
        }

        // Опционально: блокируем/разблокируем курсор
        Cursor.lockState = isUIOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isUIOpen;
    }

    // Важно: при уничтожении объекта вернуть нормальную скорость времени
    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}