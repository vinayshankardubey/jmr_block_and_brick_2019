using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] int breakableBlocks; // serialized for debugging purposes - not to change it in Unity
    [SerializeField] string levelTitle;

    // cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>(); // grabs the Sceneloader from this level
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BLockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }

    public string GetLevelTitle()
    {
        return levelTitle;
    }
}
