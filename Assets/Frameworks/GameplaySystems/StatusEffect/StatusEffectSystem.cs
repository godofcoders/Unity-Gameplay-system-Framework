using UnityEngine;

public class StatusEffectSystem : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.Subscribe<DamageEvent>(OnDamageTaken);
    }

    private void OnDamageTaken(DamageEvent damageEvent)
    {
        Debug.Log("Status effect triggered after damage.");
    }
}