using UnityEngine;
using UnityEditor;
using System;

public class FurnitureEditorWindow : EditorWindow {

    private FurnitureSettings furnitureSettings;
    private Furniture target;

    private int positionCount;
    private const int guiOffset = 25;
    private string furnitureName = "Default";
    private GameObject obj;
    private GameObject mesh;

    private bool hasTarget = false;

    [MenuItem("Window/Custom/FurnitureEditing")]
    private static void OpenWindow() {
        FurnitureEditorWindow window = GetWindow<FurnitureEditorWindow>();
        window.titleContent = new GUIContent("Furnitures");
        window.Show();
    }

    private void OnGUI() {
        positionCount = 1;
        GUI.Label(new Rect(3, 3, position.width - 6, 20), "Welcome to the furniture editor!", EditorStyles.boldLabel);
        furnitureName = EditorGUI.TextField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Name: ", furnitureName);
        mesh = (GameObject)EditorGUI.ObjectField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Mesh: ", mesh, typeof(GameObject), false);
        furnitureSettings = (FurnitureSettings)EditorGUI.ObjectField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20),
                                                           "Furniture Settings", furnitureSettings, typeof(FurnitureSettings), false);
        hasTarget = EditorGUI.Toggle(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Has a target", hasTarget);
        if (hasTarget) {
            target = (Furniture)EditorGUI.ObjectField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20),
                                                       "Target To Hit: ", target, typeof(Furniture), false);
        }

        if (mesh != null) {
            if (GUI.Button(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Create Furniture")) {
                string localPath = "Assets/Prefabs/Furnitures/" + furnitureName + ".prefab";
                if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject))) {
                    if (EditorUtility.DisplayDialog("Are you sure?",
                        "This Prefab Furniture already exists. Do you want to overwrite it?",
                        "Yes",
                        "No")) {
                        InitObject();
                        GameObject prefab = PrefabUtility.SaveAsPrefabAsset(obj, localPath);
                        DestroyImmediate(obj);
                        OpenWindow();
                    }
                }
                else {
                    InitObject();
                    GameObject prefab = PrefabUtility.SaveAsPrefabAsset(obj, localPath);
                    DestroyImmediate(obj);
                    OpenWindow();
                }
            }
        }
    }

    private void InitObject() {
        obj = new GameObject(furnitureName);
        mesh = Instantiate(mesh);
        mesh.transform.parent = obj.transform;
        GameObject cols = new GameObject("Colliders");
        if (hasTarget) SetupRaycasting();
        Furniture furniture = obj.AddComponent<Furniture>();
        furniture.Settings = furnitureSettings;
        cols.AddComponent<FurnitureCollisionManager>();
        GameObject col = new GameObject("Collider");
        col.AddComponent<FurnitureCollider>();
        col.layer = LayerMask.NameToLayer("Walls");
        col.tag = "FurnitureBlueprint";
        BoxCollider box = col.AddComponent<BoxCollider>();
        box.size = new Vector3(0.75f, 0.75f, 0.75f);
        box.isTrigger = true;
        GameObject crossGroup = new GameObject("Crossgroup");
        crossGroup.AddComponent<CrossHandler>();
        GameObject cross = (GameObject)Resources.Load("Icons/NotPlaceable", typeof(GameObject));
        GameObject notPlaceablePrefab = (GameObject)PrefabUtility.InstantiatePrefab(cross);
        cols.transform.parent = obj.transform;
        col.transform.parent = cols.transform;
        crossGroup.transform.parent = cols.transform;
        notPlaceablePrefab.transform.parent = crossGroup.transform;
    }

    private void SetupRaycasting() {
        GameObject rays = new GameObject("RaycastForObject");
        GameObject rayBox = new GameObject("RayBox");
        rayBox.layer = LayerMask.NameToLayer("Walls");
        rayBox.tag = "FurnitureBlueprint";
        MeshFilter filter = rayBox.AddComponent<MeshFilter>();
        MeshRenderer ren = rayBox.AddComponent<MeshRenderer>();
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        filter.sharedMesh = cube.GetComponent<MeshFilter>().sharedMesh;
        ren.sharedMaterial = cube.GetComponent<MeshRenderer>().sharedMaterial;
        DestroyImmediate(cube);
        rayBox.AddComponent<WingDetection>();
        GameObject notLinked = (GameObject)Resources.Load("Icons/NotLinked", typeof(GameObject));
        GameObject notCompletedPrefab = (GameObject)PrefabUtility.InstantiatePrefab(notLinked);
        notCompletedPrefab.transform.parent = rays.transform;
        GameObject linked = (GameObject)Resources.Load("Icons/Linked", typeof(GameObject));
        GameObject completedPrefab = (GameObject)PrefabUtility.InstantiatePrefab(linked);
        completedPrefab.transform.parent = rays.transform;
        RaycastTargeting rt = rays.AddComponent<RaycastTargeting>();
        rt.Target = target;
        rt.NotDone = notCompletedPrefab;
        rt.Done = completedPrefab;
        rayBox.transform.parent = rays.transform;
        rays.transform.parent = obj.transform;
    }
}