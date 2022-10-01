#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.Assertions;

public class DebugManager : MonoBehaviour
{
    public bool keepSceneViewWhenPlayButtonPressed = false;

    private void Awake()
    {
        Assert.raiseExceptions = true;
        
        if (keepSceneViewWhenPlayButtonPressed)
        {
            UnityEditor.EditorWindow.FocusWindowIfItsOpen<UnityEditor.SceneView>();
        }
    }
}
#endif