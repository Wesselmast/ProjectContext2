using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FurniturePlacementTool : EditorWindow {
    [MenuItem("Window/Custom/FurniturePlacement")]
    private static void OpenWindow() {
        FurniturePlacementTool window = GetWindow<FurniturePlacementTool>();
        window.titleContent = new GUIContent("Furniture");
        window.Show();
    }

    private void OnGUI() {
        
    }
}