using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BossCheck : MonoBehaviour
{
    [SerializeField] private GameObject bossObject; // Объект, который мы проверяем
    [SerializeField] private string bossTag; // Или можно проверять по тегу

    public UnityEvent onBossDestroyed; // Действие, которое выполнится при отсутствии объекта
    [SerializeField] private bool useTagInstead = false; // Проверять по тегу вместо объекта

    private void Update()
    {
        if (useTagInstead)
        {
            // Проверка по тегу
            if (GameObject.FindGameObjectWithTag(bossTag) == null)
            {
                BossDestroyedAction();
            }
        }
        else
        {
            // Проверка по конкретному объекту
            if (bossObject == null)
            {
                BossDestroyedAction();
            }
        }
    }

    private void BossDestroyedAction()
    {
        // Выполняем действие (можно настроить в инспекторе через UnityEvent)
        StartCoroutine(LoadAfterDelay("Menu", 2f));

        // Отключаем скрипт, чтобы не проверять каждый кадр после срабатывания
        enabled = false;
    }

    private IEnumerator LoadAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}