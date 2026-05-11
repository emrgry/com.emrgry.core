# Changelog

## [1.1.0] — 2026-05-11

### Added
- `SceneLoader.ProgressChanged` event so loading UI can subscribe to non-networked scene transitions through the same channel pattern as `SceneLoadProgressEvent` from `com.emrgry.network`.
- `SceneLoader.LoadSceneTaskAsync` — UniTask-based awaitable variant.
- Per-frame progress reporting in `LoadSceneAsync` (coroutine).

### Changed
- `com.emrgry.core.Runtime` asmdef now references `UniTask` (already an implicit transitive dep of dependent packages but now explicit).
- `package.json` `dependencies` now lists `com.cysharp.unitask` so package resolution surfaces the requirement.

### Migration
- No breaking changes. Existing `SceneLoader.LoadScene(name)` and `LoadSceneAsync(name)` callers continue to work.
- To get loading progress in your UI, subscribe to `SceneLoader.ProgressChanged` in `OnEnable` and unsubscribe in `OnDisable`.

## [1.0.3] — Previous release
- Initial public APIs: `IEventBus`/`EventBus`, `ServiceLocator`, `SceneLoader`, `ICameraMode`/`ICameraModeService`.
