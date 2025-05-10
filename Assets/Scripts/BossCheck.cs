using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BossCheck : MonoBehaviour
{
    [SerializeField] private GameObject bossObject; // ������, ������� �� ���������
    [SerializeField] private string bossTag; // ��� ����� ��������� �� ����

    public UnityEvent onBossDestroyed; // ��������, ������� ���������� ��� ���������� �������
    [SerializeField] private bool useTagInstead = false; // ��������� �� ���� ������ �������

    private void Update()
    {
        if (useTagInstead)
        {
            // �������� �� ����
            if (GameObject.FindGameObjectWithTag(bossTag) == null)
            {
                BossDestroyedAction();
            }
        }
        else
        {
            // �������� �� ����������� �������
            if (bossObject == null)
            {
                BossDestroyedAction();
            }
        }
    }

    private void BossDestroyedAction()
    {
        // ��������� �������� (����� ��������� � ���������� ����� UnityEvent)
        StartCoroutine(LoadAfterDelay("Menu", 2f));

        // ��������� ������, ����� �� ��������� ������ ���� ����� ������������
        enabled = false;
    }

    private IEnumerator LoadAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}