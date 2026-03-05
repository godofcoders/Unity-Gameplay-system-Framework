using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    public int invincibilityPotions = 1;
    public float potionDuration = 10f; // 10 seconds

    void Update()
    {
        // Press 'E' to use the invincibility potion
        if (Input.GetKeyDown(KeyCode.E) && invincibilityPotions > 0)
        {
            UsePotion();
        }
    }

    public void UsePotion()
    {
        invincibilityPotions--;
        EventBus.OnInvincibilityRequested?.Invoke(potionDuration);
        Debug.Log("Invincibility Potion used! Drain stopped for 10 seconds.");
    }
}