using UnityEngine;

namespace UI
{
    public class Parallax : MonoBehaviour
    {
        private Transform target; 
        private Material material; 

        [SerializeField]
        private float scale = 1.0f; 

        private Vector2 offset = Vector2.zero; 

        private void Start()
        {
            target = transform.root;
            material = GetComponent<SpriteRenderer>().material;
        }

        private void Update()
        {
            CalculateOffset();
            ApplyOffset();
        }

        private void CalculateOffset()
        {
            float x = target.position.x / 100f / scale;
            float y = 0f;
            offset = new Vector2(x, y);
        }

        private void ApplyOffset()
        {
            material.mainTextureOffset = offset;
        }
    }
}

