# Unity Gameplay Systems Framework

A modular gameplay architecture built in Unity demonstrating  
event-driven communication and decoupled gameplay systems.

## Features
- Event Bus communication
- Service Locator for shared services
- Modular gameplay systems
- Sample gameplay scene

## Systems Included
- Health System
- Ability System
- Inventory System
- Status Effect System

## Architecture
The framework separates gameplay logic into modular systems that  
communicate through an EventBus to avoid direct dependencies.

## Folder Structure
Assets/Framework  
Assets/Samples


![Architecture](docs/Arch.png)


## Usage

### Casting an Ability

```csharp
var ability = player.GetComponent<AbilityComponent>();
ability.CastAbility(enemy);
```

### Internal Flow

1. AbilityComponent raises an ability request.
2. The request is broadcast through the EventBus.
3. The Ability System validates cooldowns and conditions.
4. Gameplay systems react to the event.
5. UI updates without direct dependency on gameplay logic.

### Benefits

- Decoupled gameplay systems  
- Scalable architecture  
- Minimal cross-system dependencies  
- Easier debugging and testing
