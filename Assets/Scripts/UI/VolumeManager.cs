using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public AudioSource audioSource; // Ссылка на компонент AudioSource

    private void Start()
    {
        // Установка начального значения громкости на основе сохраненного значения
        InitializeVolume();
    }

    private void Update()
    {
        // Обновление значения громкости на основе сохраненного значения
        UpdateVolume();
    }

    private void InitializeVolume()
    {
        // Если сохраненного значения громкости нет, устанавливаем максимальное значение
        if (!PlayerPrefs.HasKey("volume"))
        {
            audioSource.volume = 1f;
        }
    }

    private void UpdateVolume()
    {
        // Обновление значения громкости на основе сохраненного значения
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
