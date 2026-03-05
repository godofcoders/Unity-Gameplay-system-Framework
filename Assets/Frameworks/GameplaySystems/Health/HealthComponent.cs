namespace Frameworks.Gameplay
{
    using UnityEngine;

    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float drainRate = 5f;

        private float _currentHealth;
        private bool _isInvincible = false;

        public float MaxHealth => maxHealth;

        public void Construct(float initialHealth)
        {
            maxHealth = initialHealth;
            _currentHealth = maxHealth;
        }

        public void SetInvincible(bool state) => _isInvincible = state;

        public void ModifyHealth(float amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth + amount, 0, maxHealth);
            EventBus.OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        }

        private void Update()
        {
            if (_currentHealth <= 0 || _isInvincible) return;

            _currentHealth -= drainRate * Time.deltaTime;

            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                EventBus.OnPlayerDied?.Invoke();
            }

            EventBus.OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        }
    }
}