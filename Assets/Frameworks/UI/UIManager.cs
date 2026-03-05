namespace Frameworks.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UIManager : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Text wastedText;
        [SerializeField] private Text abilityText;
        [SerializeField] private Text inventoryText;


        // Called manually by the GameBootstrap (IOC)
        public void Initialize()
        {
            if (wastedText != null)
                wastedText.gameObject.SetActive(false);

            if (healthSlider != null)
                healthSlider.value = 1f;

            Debug.Log("<color=cyan>UI System: Initialized via Bootstrap.</color>");
        }

        private void OnEnable()
        {
            // Subscribe to global events
            EventBus.OnHealthChanged += UpdateHealthSlider;
            EventBus.OnHealRequested += UpdateAbilityText;
            EventBus.OnInvincibilityRequested += UpdateInventoryText;
            EventBus.OnPlayerDied += ShowWastedScreen;
        }

        private void OnDisable()
        {
            // Unsubscribe to prevent memory leaks/null reference errors
            EventBus.OnHealthChanged -= UpdateHealthSlider;
            EventBus.OnPlayerDied -= ShowWastedScreen;
            EventBus.OnHealRequested -= UpdateAbilityText;
            EventBus.OnInvincibilityRequested -= UpdateInventoryText;
        }

        private void UpdateHealthSlider(float current, float max)
        {
            if (healthSlider == null) return;

            // Calculate percentage (0 to 1) for the slider
            healthSlider.value = current / max;
        }

        private void UpdateAbilityText(float duration, int count)
        {
            if (abilityText == null) return;

            abilityText.text = count.ToString();
        }

        private void UpdateInventoryText(float duration, int count)
        {
            if (inventoryText == null) return;

            inventoryText.text = count.ToString();
        }

        private void ShowWastedScreen()
        {
            if (wastedText == null) return;

            wastedText.gameObject.SetActive(true);
            Debug.Log("UI System: Displaying Wasted Screen.");
        }
    }
}