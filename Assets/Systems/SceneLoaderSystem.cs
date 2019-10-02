using UnityEngine;
using FYFY;
using UnityEngine.SceneManagement;  

public class SceneLoaderSystem : FSystem {
    public static SceneLoaderSystem instance;

    public SceneLoaderSystem()
    {
        instance = this;
    }
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
	}

    public void onLoadGame()
    {
        Debug.Log("Test");
        GameObjectManager.loadScene(1);

    }
}