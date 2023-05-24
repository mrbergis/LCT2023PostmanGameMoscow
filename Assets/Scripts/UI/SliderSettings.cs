using UnityEngine;
using UnityEngine.UI;

public class SliderSettings : MonoBehaviour
{
    public Slider slider; // Ссылка на компонент Slider

    private float oldVolume; // Предыдущее значение громкости

    private void Start()
    {
        // Инициализация начального значения громкости
        InitializeVolume();
    }

    private void Update()
    {
        // Проверка изменения значения громкости
        CheckVolumeChange();
    }

    private void InitializeVolume()
    {
        oldVolume = slider.value; // Запоминаем предыдущее значение громкости

        // Установка начального значения громкости на основе сохраненного значения
        if (!PlayerPrefs.HasKey("volume"))
        {
            slider.value = 1f; // Если сохраненного значения нет, устанавливаем максимальное значение
        }
        else
        {
            slider.value = PlayerPrefs.GetFloat("volume"); // Если есть сохраненное значение, устанавливаем его
        }
    }

    private void CheckVolumeChange()
    {
        // Проверка изменения значения громкости
        if (oldVolume != slider.value)
        {
            // Если значение изменилось, сохраняем новое значение и обновляем предыдущее
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
