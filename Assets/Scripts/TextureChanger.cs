using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    public Texture normalTexture;
    public Texture boostedTexture;

    private Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoostTrigger"))
        {
            objectRenderer.material.mainTexture = boostedTexture;
        }
        else if (other.CompareTag("SpeedResetTrigger"))
        {
            objectRenderer.material.mainTexture = normalTexture;
        }
    }
}
