using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditorInternal;
using UnityEditor;

namespace Shaker
{
    public static class EditorUtils
    {
        public static void OpenLockInspector(Object target)
        {
            var inspectorType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");
            var inspectorInstance = ScriptableObject.CreateInstance(inspectorType) as EditorWindow;
            inspectorInstance.Show();
            var prevSelection = Selection.activeGameObject;
            Selection.activeObject = target;
            var isLocked = inspectorType.GetProperty("isLocked", BindingFlags.Instance | BindingFlags.Public);
            isLocked.GetSetMethod().Invoke(inspectorInstance, new object[] { true });
            Selection.activeGameObject = prevSelection;
        }

        public static void FocusObject(Object obj)
        {
            EditorApplication.ExecuteMenuItem("Window/General/Inspector");
            AssetDatabase.OpenAsset(obj);
        }

    }
}

