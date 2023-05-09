using UnityEngine;
using UnityEditor.SceneManagement;

public class DirtyUtil
{
    public static void MarkSceneDirty()
    {
        #if UNITY_EDITOR
            if(!EditorSceneManager.GetActiveScene().isDirty && !Application.isPlaying) {
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene()); 
            }
        #endif
    }
}