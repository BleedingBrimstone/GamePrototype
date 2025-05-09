using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("���������")]
    [SerializeField] private GameObject uiElement; // UI-������� ��� ������������
    [SerializeField] private bool pauseGame = true; // ����� �� ����� ��� �������� UI?
    [SerializeField] private KeyCode toggleKey = KeyCode.Tab; // ������� ��� ������������

    private bool isUIOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleUI();
        }
    }

    // ����� ��� ������������ UI � �����
    public void ToggleUI()
    {
        isUIOpen = !isUIOpen;

        // ����������� UI
        if (uiElement != null)
        {
            uiElement.SetActive(isUIOpen);
        }

        // ������/������� �����
        if (pauseGame)
        {
            Time.timeScale = isUIOpen ? 0f : 1f; // 0 - �����, 1 - ���������� ��������
        }

        // �����������: ���������/������������ ������
        Cursor.lockState = isUIOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isUIOpen;
    }

    // �����: ��� ����������� ������� ������� ���������� �������� �������
    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}