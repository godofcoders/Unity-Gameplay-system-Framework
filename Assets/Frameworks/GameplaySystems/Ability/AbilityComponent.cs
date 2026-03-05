using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    public int abilityUses = 3;
    public float healPercentage = 0.20f; // 20%

    void Start()
    {
        Debug.Log("AbilityComponent: Ready to use abilities.");
        EventBus.OnHealRequested?.Invoke(0, abilityUses);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && abilityUses > 0)
        {
            UseAbility();
        }
    }

    public void UseAbility()
    {
        abilityUses--;
        EventBus.OnHealRequested?.Invoke(healPercentage, abilityUses);
        Debug.Log($"Ability used! Remaining uses: {abilityUses}");
    }
}