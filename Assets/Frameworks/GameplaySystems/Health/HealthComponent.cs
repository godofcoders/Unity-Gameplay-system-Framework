using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;

        EventBus.Publish(new DamageEvent
        {
            Target = gameObject,
            Amount = amount
        });

        if (CurrentHealth <= 0)
        {
            EventBus.Publish(new DeathEvent
            {
                Target = gameObject
            });
        }
    }
}

public struct DamageEvent
{
    public GameObject Target;
    public int Amount;
}

public struct DeathEvent
{
    public GameObject Target;
}