using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CreateNewLevel : MonoBehaviour
{
    [MenuItem("LevelEditing/CreateNew")]
    public static void CreateNewLevelFunct()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        scene.name = "New Level"; 

        //Create the new level object. 
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/LevelObject.prefab"); 

        var levelprefab = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        PrefabUtility.UnpackPrefabInstance(levelprefab, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);

        //delete the Main Camera. 
        //var cam = Object.FindObjectOfType<Camera>();
        //DestroyImmediate(cam.gameObject);

        //add the GameManager
        var gmpre = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/GameManager.prefab");

        PrefabUtility.InstantiatePrefab(gmpre);
    }
}
