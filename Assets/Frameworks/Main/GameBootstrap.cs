using UnityEngine;
using Frameworks.Gameplay;
using Frameworks.UI;

namespace Frameworks.Main
{
    [DefaultExecutionOrder(-100)]
    public class GameBootstrap : MonoBehaviour
    {
        [Header("System References")]
        [SerializeField] private UIManager uiManager;
        private HealthComponent healthComponent;
        private AbilityComponent abilityComponent;
        private InventoryComponent inventoryComponent;
        [SerializeField] private StatusEffects statusEffectManager;

        [Header("Player Spawning")]
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform playerSpawnPoint;

        private void Awake()
        {
            ResetEventBus();

            // 1. Initialize permanent systems
            if (uiManager != null) uiManager.Initialize();

            // 2. Spawn and Wire the Player
            SpawnAndWirePlayer();

            Debug.Log("<color=green>Bootstrapper: Dynamic Wiring Complete.</color>");
        }

        private void SpawnAndWirePlayer()
        {
            if (playerPrefab == null || playerSpawnPoint == null)
            {
                Debug.LogError("Bootstrapper: Prefab or SpawnPoint missing!");
                return;
            }

            // A. Instantiate the player
            GameObject playerInstance = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);

            // B. Capture the HealthComponent from the instance
            healthComponent = playerInstance.GetComponent<HealthComponent>();

            if (healthComponent != null)
            {
                // C. Initialize the health data
                healthComponent.Construct(100f);

                // D. INJECTION: Hand the health reference to the StatusEffectManager
                // This fulfills the "Ability System -> Status Effects -> Health" flow
                if (statusEffectManager != null)
                {
                    statusEffectManager.Construct(healthComponent);
                }
            }
            else
            {
                Debug.LogError("Bootstrapper: Spawned player is missing a HealthComponent!");
            }
        }

        private void ResetEventBus()
        {
            EventBus.OnHealthChanged = null;
            EventBus.OnPlayerDied = null;
            EventBus.OnHealRequested = null;
            EventBus.OnInvincibilityRequested = null;
        }
    }
}