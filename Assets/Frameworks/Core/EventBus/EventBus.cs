using System;

public static class EventBus
{
    // UI Events
    public static Action<float, float> OnHealthChanged;
    public static Action OnPlayerDied;

    // Gameplay Logic Events
    public static Action<float> OnHealRequested;
    public static Action<float> OnInvincibilityRequested;
}