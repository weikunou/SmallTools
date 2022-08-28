using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void LoadTargetScene(string from, string to)
    {
        StartCoroutine(LoadTargetSceneAsync(from, to));
    }

    private IEnumerator LoadTargetSceneAsync(string from, string to)
    {
        Scene sceneFrom = SceneManager.GetSceneByName(from);
        if(sceneFrom.isLoaded)
        {
            yield return SceneManager.UnloadSceneAsync(from);
        }
        Scene sceneTo = SceneManager.GetSceneByName(to);
        if(!sceneTo.isLoaded)
        {
            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
            Scene scene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(scene);
        }
    }
}
