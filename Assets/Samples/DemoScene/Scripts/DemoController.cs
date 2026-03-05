using UnityEngine;

public class DemoController : MonoBehaviour
{
    public AbilityComponent playerAbility;
    public GameObject enemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAbility.CastAbility(enemy);
        }
    }
}