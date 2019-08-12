using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Modules))]
public sealed class ModulesEditor : Editor
{
    private Modules _modules;

    public override void OnInspectorGUI()
    {
        if (!_modules)
            _modules = target as Modules;

        GUILayout.Space(20f);

        GUILayout.BeginVertical();

        List<Module> toRemove = new List<Module>();

        foreach (Module m in _modules)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Label(m.GetName());
            if (GUILayout.Button("Remove", GUILayout.MaxWidth(60)))
            {
                Undo.RecordObject(_modules, "Removed Module");
                toRemove.Add(m);
            }

            GUILayout.EndHorizontal();

            EditorGUILayoutExtension.HorizontalLine();
        }

        _modules.Remove(toRemove);

        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Add"))
        {
            LoadModuleSelector();
        }

        GUILayout.Space(35f);

        if (GUILayout.Button("Clear"))
        {
            Undo.RecordObject(_modules, "Cleared modules");

            _modules.Clear();
        }

        GUILayout.EndHorizontal();
    }

    private void LoadModuleSelector()
    {
        string[] guids = AssetDatabase.FindAssets("t:Module", new string[] { "Assets/ScrObj" });

        GenericMenu menu = new GenericMenu();

        foreach (string id in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(id);
            Module m = AssetDatabase.LoadAssetAtPath<Module>(assetPath);

            menu.AddItem(new GUIContent(m.GetName()), false, (obj) =>
            {
                Undo.RecordObject(_modules, "Added Module");

                // Add new module
                if (!_modules.Add(m))
                {
                    Debug.LogError("Cannot have more than one module of same type.");
                }
            }, id);
        }

        menu.ShowAsContext();
    }
}
