using UnityEngine;
using UnityEngine.UI;

public class SliderSettings : MonoBehaviour
{
    public Slider slider; // ������ �� ��������� Slider

    private float oldVolume; // ���������� �������� ���������

    private void Start()
    {
        // ������������� ���������� �������� ���������
        InitializeVolume();
    }

    private void Update()
    {
        // �������� ��������� �������� ���������
        CheckVolumeChange();
    }

    private void InitializeVolume()
    {
        oldVolume = slider.value; // ���������� ���������� �������� ���������

        // ��������� ���������� �������� ��������� �� ������ ������������ ��������
        if (!PlayerPrefs.HasKey("volume"))
        {
            slider.value = 1f; // ���� ������������ �������� ���, ������������� ������������ ��������
        }
        else
        {
            slider.value = PlayerPrefs.GetFloat("volume"); // ���� ���� ����������� ��������, ������������� ���
        }
    }

    private void CheckVolumeChange()
    {
        // �������� ��������� �������� ���������
        if (oldVolume != slider.value)
        {
            // ���� �������� ����������, ��������� ����� �������� � ��������� ����������
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }
}
