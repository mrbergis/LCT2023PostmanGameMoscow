using UnityEngine;
using UnityEngine.Events;

namespace Attributes
{
    public class Health : MonoBehaviour
    {
        bool _isDead = false;
        
        [field: SerializeField]
        public UnityEvent OnPlayerDie { get; set; }
        
        public bool IsDead()
        {
            return _isDead;
        }
        
        public void Die()
        {
            if (_isDead) return;

            _isDead = true;
            GetComponent<Animator>().SetTrigger("Lose");
            
            OnPlayerDie?.Invoke();
        }
        
    }
}
