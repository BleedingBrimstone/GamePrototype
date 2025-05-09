using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition: MonoBehaviour
{
    [SerializeField] private string nextSceneName; // Имя следующей сцены (укажи в инспекторе)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Проверяем, что вошёл игрок
        {
            SceneManager.LoadScene(nextSceneName); // Загружаем следующую сцену
        }
    }
}