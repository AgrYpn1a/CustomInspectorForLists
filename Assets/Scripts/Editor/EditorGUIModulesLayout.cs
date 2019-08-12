using UnityEditor;
using UnityEngine;

public static class EditorGUILayoutExtension
{
    public static void HorizontalLine() => HorizontalLine(Color.gray, 1f);

    public static void HorizontalLine(Color color, float height)
    {
        GUILayout.Space(10f);

        EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, height), color);

        GUILayout.Space(10f);
    }
}
