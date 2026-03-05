// Core.asmdef
public interface IGameSystem
{
    void Initialize();
}

public interface IUISystem : IGameSystem
{
    void SetWastedText(bool active);
}