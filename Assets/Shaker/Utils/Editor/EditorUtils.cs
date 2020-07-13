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

        [MenuItem("Shaker/Open Terminal")]
        static void OpenTerminal()
        {

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                System.Diagnostics.Process.Start("CMD.exe", "cd " + GetProjectPath());
            }
            else if (Application.platform == RuntimePlatform.OSXEditor)
            {
                System.Diagnostics.Process.Start(@"/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal", "cd " + GetProjectPath());
            }
            else
            {
                Debug.LogWarning("Terminal shortcut is not supported on your plateform");
            }
        }

        public static string GetProjectPath()
        {
            string path = Application.dataPath;
            path = path.Replace("/Assets", "");
            return path;
        }

#if UNITY_EDITOR_OSX
    [MenuItem("Shaker/Reveal in Finder")]
#else
        [MenuItem("Shaker/Show in Explorer")]
#endif
        static void OpenInFileExplorer()
        {
            EditorUtility.RevealInFinder(GetProjectPath());
        }

    }
}

