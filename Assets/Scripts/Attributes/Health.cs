using UnityEngine;

namespace Attributes
{
    public class Health : MonoBehaviour
    {
        bool _isDead = false;
        
        public bool IsDead()
        {
            return _isDead;
        }
        
        public void Die()
        {
            if (_isDead) return;

            _isDead = true;
            GetComponent<Animator>().SetTrigger("Lose");
        }
        
    }
}
