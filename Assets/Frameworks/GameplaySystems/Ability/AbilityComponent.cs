using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    public int abilityUses = 3;
    public float healPercentage = 0.20f; // 20%

    void Update()
    {
        // Press 'Q' to use the heal ability
        if (Input.GetKeyDown(KeyCode.Q) && abilityUses > 0)
        {
            UseAbility();
        }
    }

    public void UseAbility()
    {
        abilityUses--;
        EventBus.OnHealRequested?.Invoke(healPercentage);
        Debug.Log($"Ability used! Remaining uses: {abilityUses}");
    }
}