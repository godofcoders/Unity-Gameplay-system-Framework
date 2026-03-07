# 🎮 Unity Gameplay Systems Framework

![Unity](https://img.shields.io/badge/Unity-2021%2B-black)
![Architecture](https://img.shields.io/badge/Architecture-Event%20Driven-blue)
![CSharp](https://img.shields.io/badge/C%23-Modular-green)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

A **modular gameplay architecture framework for Unity** demonstrating how to build **decoupled gameplay systems** using:

* Event-driven communication
* Manual dependency wiring
* Assembly definition boundaries
* Modular gameplay systems

The goal of this project is to demonstrate **clean gameplay architecture patterns commonly used in large-scale Unity projects**.

---

# 🚀 Overview

Traditional Unity gameplay logic often becomes tightly coupled due to:

* Direct component references
* Frequent use of `Find()` or `GetComponent()` chains
* Systems depending directly on each other

This framework solves that by introducing:

* **Event Bus communication**
* **Manual Composition Root (Bootstrapper)**
* **Assembly definition modularization**

Systems communicate **indirectly through events**, allowing gameplay features to remain **fully modular and easily expandable**.

---

# 🧠 Key Features

### Event Bus Communication

Gameplay systems interact using a **centralized event bus** rather than direct references.

Example flow:

```
Ability → EventBus → StatusEffectManager → HealthComponent
```

Benefits:

* Systems remain decoupled
* Easy feature expansion
* Reduced dependency chains

---

### Manual Composition Root

All gameplay systems are **wired together explicitly** inside a bootstrapper.

This follows **Inversion of Control (IoC)** principles.

Example:

```csharp
var health = player.GetComponent<HealthComponent>();
statusEffectManager.Construct(health);
```

Benefits:

* Explicit dependencies
* Easier debugging
* Better memory safety

---

### Assembly Definition Separation

The project uses **Unity Assembly Definitions (`.asmdef`)** to enforce modular boundaries.

This prevents accidental cross-system dependencies.

---

### Memory-Safe Event Lifecycle

Events are properly reset and unsubscribed to prevent:

* Event leaks
* Stale references
* Hidden memory issues

---

# 🧩 Gameplay Systems Included

The framework includes several modular gameplay systems.

| System                   | Description                                             |
| ------------------------ | ------------------------------------------------------- |
| **Health System**        | Handles player health and draining logic                |
| **Ability System**       | Provides a 3-charge ability that heals 20% HP           |
| **Inventory System**     | Contains consumables such as a 10s invincibility potion |
| **Status Effect System** | Acts as an intermediary applying gameplay effects       |

These systems communicate **indirectly through the EventBus**.

---

# 🏗️ Architecture

The framework separates gameplay logic into multiple assemblies.

A central **Bootstrapper** in the `Main` assembly performs **manual dependency wiring**.

This ensures systems remain:

* Decoupled
* Explicitly initialized
* Easier to debug and test

---

# 📂 Folder Structure

```
Assets/Frameworks/

Core/
Gameplay/
UI/
Main/
```

### Assembly Responsibilities

| Assembly     | Purpose                                    |
| ------------ | ------------------------------------------ |
| **Core**     | Shared utilities and EventBus              |
| **Gameplay** | Gameplay systems and components            |
| **UI**       | UI controllers reacting to gameplay events |
| **Main**     | Composition root and system initialization |

---

# 🏗️ Architecture Diagram

![Architecture](docs/Arch.png)

---

# 🔄 Gameplay Flow

Below is the typical gameplay interaction flow.

### 1️⃣ Ability or Inventory Request

An ability or item triggers a request via the EventBus.

Example:

```
AbilityComponent → EventBus
```

---

### 2️⃣ Event Broadcast

The request is broadcast globally.

No direct reference to a receiver is required.

---

### 3️⃣ Status Effect Processing

The `StatusEffectManager` listens for the request event and applies the appropriate logic.

Example:

```
Heal
Invincibility
Status effects
```

---

### 4️⃣ Health Update

The `HealthComponent` updates its state:

* Heal
* Pause damage drain
* Apply effects

Then it broadcasts a **HealthChanged event**.

---

### 5️⃣ UI Update

The `UIManager` listens to the event and updates the HUD.

Example updates:

* Health bar
* Status indicators
* Ability cooldown UI

---

# ⚡ Benefits of This Architecture

* Decoupled gameplay systems
* Scalable modular architecture
* Assembly definition safety
* Event-driven communication
* Clear dependency management
* Reduced hidden references

---

# 🎯 Ideal Use Cases

This architecture is ideal for projects requiring:

* Modular gameplay systems
* Ability systems
* Status effect frameworks
* Event-driven UI updates
* Scalable gameplay codebases

---

# 📌 Requirements

* **Unity 2021+**
* C# 9+
* Assembly Definition support

---

# 📄 License

MIT License.

---
