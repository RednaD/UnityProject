using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    List<Object>    _openedScenes = new List<Object>();

    // Scene management

    public void GoToScene(Object sceneAsset)
    {
        Scene scene;
        int nb  = SceneManager.sceneCount;
        for (int i = 0; i < nb; i++)
        {
            scene = SceneManager.GetSceneAt(i);
            if (scene.name != "Test_Main")
                SceneManager.UnloadSceneAsync(scene);
        }
        SceneManager.LoadScene(sceneAsset.name, LoadSceneMode.Additive);
    }
    
    public void TMPGoToScene(Object sceneAsset)
    {
        SceneManager.LoadScene(sceneAsset.name);
    }

    public void AddAdditiveScene(Object newScene)
    {
        if (!newScene) return;
        _openedScenes.Add(newScene);
        SceneManager.LoadScene(newScene.name, LoadSceneMode.Additive);
    }
    
    public void RemoveAdditiveScene(Object toRemoveScene)
    {
        if (!toRemoveScene || !_openedScenes.Contains(toRemoveScene)) return;
        _openedScenes.Remove(toRemoveScene);
        SceneManager.UnloadSceneAsync(toRemoveScene.name);
    }
}
