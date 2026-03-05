using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    void Awake()
    {
        ServiceLocator.Register(new LoggingService());
    }
}