using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks = 0;

    // Cached references
    SceneLoader sceneLoader;

    public void CountBlocks() {
        ++breakableBlocks;
    }

    public void DestroyBlock() {
        --breakableBlocks;
        if(breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }

    private void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
}
