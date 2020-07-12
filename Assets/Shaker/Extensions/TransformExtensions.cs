using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shaker
{
    public static class TransformExtensions
    {

        #region DESTROY EXTENSIONS
            public static void DestroyChildren(this Transform t, float delay = 0)
            {
                int childs = t.childCount;
                for (int i = childs - 1; i >= 0; i--)
                {
                    GameObject.Destroy(t.GetChild(i).gameObject, delay);
                }
            }
            public static void DestroyChildrenImmediate(this Transform t, float delay = 0)
            {
                int childs = t.childCount;
                for (int i = childs - 1; i >= 0; i--)
                {
                    GameObject.DestroyImmediate(t.GetChild(i).gameObject);
                }
            }
        #endregion

        #region POSITIONS EXTENSIONS
        public static void SetPositionX(this Transform t, float value)
            {
                t.position = new Vector3(value, t.position.y, t.position.z);
            }
            public static void SetPositionY(this Transform t, float value)
            {
                t.position = new Vector3(t.position.x, value, t.position.z);
            }
            public static void SetPositionZ(this Transform t, float value)
            {
                t.position = new Vector3(t.position.x, t.position.y, value);
            }
            public static void SetLocalPositionX(this Transform t, float value)
            {
                t.localPosition = new Vector3(value, t.localPosition.y, t.localPosition.z);
            }
            public static void SetLocalPositionY(this Transform t, float value)
            {
                t.localPosition = new Vector3(t.localPosition.x, value, t.localPosition.z);
            }
            public static void SetLocalPositionZ(this Transform t, float value)
            {
                t.localPosition = new Vector3(t.localPosition.x, t.localPosition.y, value);
            }
        #endregion

        #region ROTATIONS EXTENSIONS
            public static void SetRotationX(this Transform t, float value)
            {
                t.eulerAngles = new Vector3(value, t.position.y, t.position.z);
            }
            public static void SetRotationY(this Transform t, float value)
            {
                t.eulerAngles = new Vector3(t.position.x, value, t.position.z);
            }
            public static void SetRotationZ(this Transform t, float value)
            {
                t.eulerAngles = new Vector3(t.position.x, t.position.y, value);
            }
            public static void SetLocalRotationX(this Transform t, float value)
            {
                t.localEulerAngles = new Vector3(value, t.localRotation.y, t.localRotation.z);
            }
            public static void SetLocalRotationY(this Transform t, float value)
            {
                t.localEulerAngles = new Vector3(t.localRotation.x, value, t.localRotation.z);
            }
            public static void SetLocalRotationZ(this Transform t, float value)
            {
                t.localEulerAngles = new Vector3(t.localRotation.x, t.localRotation.y, value);
            }
        #endregion 
    }
}
