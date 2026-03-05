using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private List<string> items = new();

    public void AddItem(string item)
    {
        items.Add(item);

        EventBus.Publish(new ItemAddedEvent
        {
            Item = item
        });
    }
}

public struct ItemAddedEvent
{
    public string Item;
}