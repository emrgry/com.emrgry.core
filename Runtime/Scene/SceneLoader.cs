using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Emrgry.Core
{
    /// <summary>
    /// Static scene loader for non-networked scene transitions.
    /// For networked scene transitions, use INetworkSceneService.
    /// </summary>
    public static class SceneLoader
    {
        public static async UniTask LoadSceneAsync(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            while (!operation.isDone)
                await UniTask.Yield();
        }

        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
