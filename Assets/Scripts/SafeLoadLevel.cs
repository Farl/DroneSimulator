using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeLoadLevel : MonoBehaviour
{
    private static SafeLoadLevel current;

    public static void LoadLevel(string sceneName)
    {
        // Use following step to load the scene
        // 1. Add a DONT DESTROY ON LOAD object to the scene
        // 2. Add SafeLoadLevel script to the object
        // 3. Call the StartLoadLevel method with the scene name
        //   1. In StartLoadLevel method, check if every scene is unloaded
        //   2. If not, unload the scene
        //   3. Load the scene
        // 4. Call the LoadLevel method with the scene name
        // 5. Destroy the DONT DESTROY ON LOAD object

        if (current)
        {
            Debug.LogWarning("SafeLoadLevel already exists!");
            return;
        }
        var go = new GameObject("SafeLoadLevel");
        current = go.AddComponent<SafeLoadLevel>();
        current.StartLoadLevel(sceneName);
    }

    private Coroutine loadLevelCoroutine;

    private IEnumerator LoadLevelCoroutine(string targetSceneName)
    {
        // Load Empty Scene and set active scene to it
        var emptyScene = SceneManager.CreateScene("Empty");
        SceneManager.SetActiveScene(emptyScene);

        // Unload all loaded scenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene != emptyScene && scene.isLoaded)
            {
                yield return SceneManager.UnloadSceneAsync(scene);
            }
        }

        // Load the target scene
        yield return SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive);

        // Set the target scene as active
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetSceneName));

        // Unload the empty scene
        yield return SceneManager.UnloadSceneAsync(emptyScene);

        // Destroy this object
        Destroy(gameObject);
    }

    public void StartLoadLevel(string targetSceneName)
    {
        DontDestroyOnLoad(gameObject);
        loadLevelCoroutine = StartCoroutine(LoadLevelCoroutine(targetSceneName));
    }
}
