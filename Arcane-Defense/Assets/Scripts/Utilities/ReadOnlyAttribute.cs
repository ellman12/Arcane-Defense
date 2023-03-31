﻿using UnityEditor;
using UnityEngine;

namespace Utilities
{
	#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	internal class ReadOnlyDrawer : PropertyDrawer
	{
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property, label, true);
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			GUI.enabled = false;
			EditorGUI.PropertyField(position, property, label, true);
			GUI.enabled = true;
		}
	}
	#endif

	///Displays a value in the Inspector that can't be modified.
	public class ReadOnlyAttribute : PropertyAttribute
	{
	}
}