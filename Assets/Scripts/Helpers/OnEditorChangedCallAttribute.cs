using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Helpers
{
    public class OnEditorChangedCallAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public OnEditorChangedCallAttribute(string methodName) => MethodName = methodName;
    }

#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(OnEditorChangedCallAttribute))]
    public class OnChangedCallAttributePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            EditorGUI.PropertyField(position, property);

            if (!EditorGUI.EndChangeCheck()) return;

            if (!(attribute is OnEditorChangedCallAttribute at)) return;

            MethodInfo method = property.serializedObject.targetObject.GetType().GetMethods()
                .FirstOrDefault(m => m.Name == at.MethodName);

            // Only invoke methods with zero parameters
            if (method != null && !method.GetParameters().Any())
                method.Invoke(property.serializedObject.targetObject, null);
        }
    }

#endif
}