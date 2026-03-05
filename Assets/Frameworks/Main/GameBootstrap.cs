using UnityEngine;
using Frameworks.Gameplay;

namespace Frameworks.Main
{
    [DefaultExecutionOrder(-100)]
    public class GameBootstrap : MonoBehaviour
    {
        [Header("System References")]
        [SerializeField] private UIManager uiManager;
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private StatusEffects statusEffectManager;

        [Header("Player Spawning")]
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private Transform playerSpawnPoint;

        private void Awake()
        {
            // 1. Clear static state (Preventing ghost subscriptions in Editor)
            ResetEventBus();

            // 2. Manual Wiring (Dependency Injection)
            // We initialize systems and inject dependencies manually
            if (uiManager != null) uiManager.Initialize();

            if (healthComponent != null)
            {
                healthComponent.Construct(100f);
            }

            // Wiring StatusEffects to Health as per your diagram
            if (statusEffectManager != null && healthComponent != null)
            {
                statusEffectManager.Construct(healthComponent);
            }

            // 3. Game Start Logic
            SpawnPlayer();

            Debug.Log("<color=green>AAA Bootstrapper: All systems wired and player spawned.</color>");
        }

        private void ResetEventBus()
        {
            EventBus.OnHealthChanged = null;
            EventBus.OnPlayerDied = null;
            EventBus.OnHealRequested = null;
            EventBus.OnInvincibilityRequested = null;
        }

        private void SpawnPlayer()
        {
            if (playerPrefab != null && playerSpawnPoint != null)
            {
                Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
            }
            else
            {
                Debug.LogWarning("Bootstrapper: Player Prefab or Spawn Point missing. Check Inspector.");
            }
        }
    }
}