using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Emrgry.Core
{
    /// <summary>
    /// Static scene loader for non-networked scene transitions.
    /// For networked scene transitions, use INetworkSceneService from com.emrgry.network.
    ///
    /// All three load variants raise <see cref="ProgressChanged"/> with values in [0,1]
    /// so a loading-screen UI can subscribe once and react to both networked and
    /// non-networked transitions through a single channel.
    /// </summary>
    public static class SceneLoader
    {
        /// <summary>
        /// Fires whenever a non-networked load advances. Args: (sceneName, progress 0..1).
        /// Progress is reported as 1f for synchronous <see cref="LoadScene"/> immediately
        /// after the call.
        /// </summary>
        public static event Action<string, float> ProgressChanged;

        /// <summary>Synchronous load. Reports progress = 1 at the end.</summary>
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            ProgressChanged?.Invoke(sceneName, 1f);
        }

        /// <summary>Coroutine-friendly async load with per-frame progress reporting.</summary>
        public static IEnumerator LoadSceneAsync(string sceneName)
        {
            var op = SceneManager.LoadSceneAsync(sceneName);
            if (op == null) yield break;

            while (!op.isDone)
            {
                ProgressChanged?.Invoke(sceneName, op.progress);
                yield return null;
            }
            ProgressChanged?.Invoke(sceneName, 1f);
        }

        /// <summary>UniTask-based async load. Awaitable and progress-reporting.</summary>
        public static async UniTask LoadSceneTaskAsync(string sceneName)
        {
            var op = SceneManager.LoadSceneAsync(sceneName);
            if (op == null) return;

            while (!op.isDone)
            {
                ProgressChanged?.Invoke(sceneName, op.progress);
                await UniTask.Yield();
            }
            ProgressChanged?.Invoke(sceneName, 1f);
        }
    }
}
