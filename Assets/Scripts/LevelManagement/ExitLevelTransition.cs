using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.LevelManagement
{
    public class ExitLevelTransition : MonoBehaviour
    {
        [SerializeField]
        private string playerTag = "Player";
        
        public UnityEvent OnTransition;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                OnTransition?.Invoke();
            }
        }
    }
}