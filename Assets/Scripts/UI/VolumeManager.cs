using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public AudioSource audioSource; // ������ �� ��������� AudioSource

    private void Start()
    {
        // ��������� ���������� �������� ��������� �� ������ ������������ ��������
        InitializeVolume();
    }

    private void Update()
    {
        // ���������� �������� ��������� �� ������ ������������ ��������
        UpdateVolume();
    }

    private void InitializeVolume()
    {
        // ���� ������������ �������� ��������� ���, ������������� ������������ ��������
        if (!PlayerPrefs.HasKey("volume"))
        {
            audioSource.volume = 1f;
        }
    }

    private void UpdateVolume()
    {
        // ���������� �������� ��������� �� ������ ������������ ��������
        audioSource.volume = PlayerPrefs.GetFloat("volume");
    }
}
