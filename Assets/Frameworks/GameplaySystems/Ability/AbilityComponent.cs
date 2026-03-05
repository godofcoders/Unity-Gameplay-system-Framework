using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    public void CastAbility(GameObject target)
    {
        var logger = ServiceLocator.Get<LoggingService>();
        logger.Log("Ability Cast!");

        var health = target.GetComponent<HealthComponent>();

        if (health != null)
        {
            health.TakeDamage(10);
        }
    }
}