# com.emrgry.core

Foundational Unity infrastructure: EventBus, ServiceLocator, SceneLoader, Camera interfaces.

## Requirements

- Unity 6000.0+
- [UniTask](https://github.com/Cysharp/UniTask) — install manually before adding this package:
  ```
  https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
  ```

## Installation

Add via Package Manager → Add package from git URL:

```
https://github.com/emrgry/com.emrgry.core.git#v1.0.3
```

## Contents

| Namespace | Class | Description |
|-----------|-------|-------------|
| `Emrgry.Core` | `IEventBus` / `EventBus` | Type-safe pub/sub event system |
| `Emrgry.Core` | `ServiceLocator` | Static service container (DI) |
| `Emrgry.Core` | `SceneLoader` | Non-networked scene loading |
| `Emrgry.Core.Camera` | `ICameraMode` / `ICameraModeService` | Camera mode interfaces |
