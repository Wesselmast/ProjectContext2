using UnityEngine;
using UnityEditor;
using System;

public class FurnitureEditorWindow : EditorWindow {

    private FurnitureSettings furnitureSettings;
    private Furniture target;

    private int positionCount;
    private const int guiOffset = 25;
    private string furnitureName = "Default";
    private GameObject mainObject;
    private GameObject meshObject;

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
        meshObject = (GameObject)EditorGUI.ObjectField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Mesh: ", meshObject, typeof(GameObject), false);
        furnitureSettings = (FurnitureSettings)EditorGUI.ObjectField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20),
                                                           "Furniture Settings", furnitureSettings, typeof(FurnitureSettings), false);
        hasTarget = EditorGUI.Toggle(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Has a target", hasTarget);
        if (hasTarget) {
            target = (Furniture)EditorGUI.ObjectField(new Rect(3, guiOffset * positionCount++, position.width - 6, 20),
                                                       "Target To Hit: ", target, typeof(Furniture), false);
        }

        if (meshObject == null) return;

        if (GUI.Button(new Rect(3, guiOffset * positionCount++, position.width - 6, 20), "Create Furniture")) {
            string localPath = "Assets/Prefabs/Furnitures/" + furnitureName + ".prefab";
            if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject))) {
                if (!EditorUtility.DisplayDialog("Are you sure?",
                    "This Prefab Furniture already exists. Do you want to overwrite it?",
                    "Yes",
                    "No")) return;
            }
            else {
                InitObject();
                GameObject prefab = PrefabUtility.SaveAsPrefabAsset(mainObject, localPath);
                DestroyImmediate(mainObject);
                OpenWindow();
            }
        }
    }

    private void InitObject() {
        mainObject = new GameObject(furnitureName);
        Furniture furniture = mainObject.AddComponent<Furniture>();
        furniture.Settings = furnitureSettings;
        meshObject = Instantiate(meshObject);
        meshObject.transform.parent = mainObject.transform;
        SetupColliders();
        if (hasTarget) SetupRaycasting();
    }

    private void SetupColliders() {
        GameObject collidersObject = new GameObject("Colliders");
        collidersObject.AddComponent<FurnitureCollisionManager>();
        CreateColliderObject().transform.parent = collidersObject.transform;
        CreateCrossGroup().transform.parent = collidersObject.transform;
        collidersObject.transform.parent = mainObject.transform;
    }

    private GameObject CreateCrossGroup() {
        GameObject crossGroup = new GameObject("Crossgroup");
        crossGroup.AddComponent<CrossHandler>();
        GameObject crossPrefab = (GameObject)Resources.Load("Icons/NotPlaceable", typeof(GameObject));
        ((GameObject)PrefabUtility.InstantiatePrefab(crossPrefab)).transform.parent = crossGroup.transform;
        return crossGroup;
    }

    private GameObject CreateColliderObject() {
        GameObject colliderObject = new GameObject("Collider");
        colliderObject.AddComponent<FurnitureCollider>();
        colliderObject.layer = LayerMask.NameToLayer("Walls");
        colliderObject.tag = "FurnitureBlueprint";
        BoxCollider boxCollider = colliderObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(0.75f, 0.75f, 0.75f);
        boxCollider.isTrigger = true;
        return colliderObject;
    }

    private void SetupRaycasting() {
        GameObject raycastForObject = new GameObject("RaycastForObject");
        GameObject rayBoxObject = CreateRayBox();
        GameObject notLinkedIcon = CreateIcon("Icons/NotLinked");
        GameObject linkedIcon = CreateIcon("Icons/Linked");
        RaycastTargeting raycastTargeting = raycastForObject.AddComponent<RaycastTargeting>();
        raycastTargeting = SetupRaycastTargeting(notLinkedIcon, linkedIcon);
        notLinkedIcon.transform.parent = raycastForObject.transform;
        linkedIcon.transform.parent = raycastForObject.transform;
        rayBoxObject.transform.parent = raycastForObject.transform;
        raycastForObject.transform.parent = mainObject.transform;
    }

    private GameObject CreateRayBox() {
        GameObject rayBoxPrefab = (GameObject)Resources.Load("Prefabs/RayBox", typeof(GameObject));
        return (GameObject)PrefabUtility.InstantiatePrefab(rayBoxPrefab);
    }

    private RaycastTargeting SetupRaycastTargeting(GameObject notLinkedIcon, GameObject linkedIcon) {
        return new RaycastTargeting {
            Target = target,
            NotLinked = notLinkedIcon,
            Linked = linkedIcon
        };
    }

    private GameObject CreateIcon(string path) {
        GameObject iconPrefab = (GameObject)Resources.Load(path, typeof(GameObject));
        return (GameObject)PrefabUtility.InstantiatePrefab(iconPrefab);
    }
}