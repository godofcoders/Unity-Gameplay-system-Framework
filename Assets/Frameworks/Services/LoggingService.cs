using UnityEngine;

public class LoggingService : IService
{
    public void Log(string message)
    {
        Debug.Log("[GameLog] " + message);
    }
}