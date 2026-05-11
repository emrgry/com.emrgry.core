# com.emrgry.core

Foundational Unity infrastructure: EventBus, ServiceLocator, SceneLoader, Camera interfaces.

## Requirements

- Unity 6000.0+
- [UniTask](https://github.com/Cysharp/UniTask) — install via git URL before adding this package:
  ```
  https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
  ```

## Installation

Add via Package Manager → Add package from git URL:

```
https://github.com/emrgry/com.emrgry.core.git#v1.1.0
```

## Contents

| Namespace | Class | Description |
|-----------|-------|-------------|
| `Emrgry.Core` | `IEventBus` / `EventBus` | Type-safe pub/sub event system |
| `Emrgry.Core` | `ServiceLocator` | Static service container (DI) |
| `Emrgry.Core` | `SceneLoader` | Non-networked scene loading with `ProgressChanged` event and UniTask variant |
| `Emrgry.Core.Camera` | `ICameraMode` / `ICameraModeService` | Camera mode interfaces |

## Usage

### Subscribing to loading progress

```csharp
private void OnEnable()  => SceneLoader.ProgressChanged += OnProgress;
private void OnDisable() => SceneLoader.ProgressChanged -= OnProgress;

private void OnProgress(string sceneName, float p) => _slider.value = p;
```

### Awaitable load

```csharp
await SceneLoader.LoadSceneTaskAsync("MainMenu");
// next frame after the load completes
```
