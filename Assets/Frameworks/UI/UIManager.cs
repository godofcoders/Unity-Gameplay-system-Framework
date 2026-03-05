// UI.asmdef (References Core)
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IUISystem
{
    [SerializeField] private Text wastedText;

    public void Initialize()
    {
        wastedText.gameObject.SetActive(false);
        Debug.Log("UI System Wired and Ready.");
    }

    public void SetWastedText(bool active) => wastedText.gameObject.SetActive(active);
}