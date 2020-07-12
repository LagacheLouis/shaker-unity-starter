using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

namespace Shaker
{
	public static class ScriptableObjectUtils
	{
		public static T CreateOrLoad<T>(string filename, string destination, bool forceNew = true) where T : ScriptableObject
		{

			string dirpath = "Assets/" + destination + "/";
			string filepath = dirpath + filename + ".asset";

			T asset = (T)AssetDatabase.LoadAssetAtPath(filepath, typeof(T));
			if (asset != null && !forceNew)
			{
				Debug.Log("Asset loaded");
				return asset;
			}
			asset = ScriptableObject.CreateInstance<T>();

			if (!Directory.Exists(dirpath))
			{
				Directory.CreateDirectory(dirpath);
			}
			Debug.Log(filepath);
			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(filepath);
			AssetDatabase.CreateAsset(asset, assetPathAndName);

			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();

			EditorUtility.FocusProjectWindow();
			Selection.activeObject = asset;

			Debug.Log("Asset created");
			return asset;
		}
	}
}

