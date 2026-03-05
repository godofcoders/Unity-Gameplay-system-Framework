namespace Frameworks.Gameplay
{
    using UnityEngine;

    public class StatusEffects : MonoBehaviour
    {
        private HealthComponent _health;
        private float _invincibilityTimer = 0f;
        private bool _isInvincible = false;

        // Manual Injection from Bootstrap
        public void Construct(HealthComponent health)
        {
            _health = health;
            Debug.Log("StatusEffects: Wired to HealthComponent.");
        }

        private void OnEnable()
        {
            EventBus.OnHealRequested += HandleHeal;
            EventBus.OnInvincibilityRequested += HandleInvincibility;
        }

        private void OnDisable()
        {
            EventBus.OnHealRequested -= HandleHeal;
            EventBus.OnInvincibilityRequested -= HandleInvincibility;
        }

        private void Update()
        {
            if (_isInvincible)
            {
                _invincibilityTimer -= Time.deltaTime;
                if (_invincibilityTimer <= 0)
                {
                    _isInvincible = false;
                    _health.SetInvincible(false); // Resume draining
                    Debug.Log("Status: Invincibility Expired.");
                }
            }
        }

        private void HandleHeal(float percentage)
        {
            if (_health == null) return;

            // Logic: Increase health by % of max
            float healAmount = _health.MaxHealth * percentage;
            _health.ModifyHealth(healAmount);
        }

        private void HandleInvincibility(float duration)
        {
            if (_health == null) return;

            _isInvincible = true;
            _invincibilityTimer = duration;
            _health.SetInvincible(true); // Stop the drain
            Debug.Log($"Status: Invincibility active for {duration}s");
        }
    }
}