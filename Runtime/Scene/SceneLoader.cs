using System.Collections;
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
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static IEnumerator LoadSceneAsync(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
