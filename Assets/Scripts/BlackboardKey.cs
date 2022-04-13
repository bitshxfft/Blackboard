using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

namespace BitwiseAI
{
	[Serializable]
	public struct BlackboardKey
	{
		[SerializeField] private string m_Key;
		[SerializeField, HideInInspector] private int m_Hash;

		// ----------------------------------------------------------------------------

		public string Key => m_Key;
		public int Hash => m_Hash;

		public bool IsValid => false == (string.IsNullOrEmpty(m_Key) || string.IsNullOrWhiteSpace(m_Key));

		// ----------------------------------------------------------------------------

		public BlackboardKey(string key)
		{
			m_Key = key ?? string.Empty;
			m_Hash = m_Key.GetHashCode();
		}

		// ----------------------------------------------------------------------------

		public override string ToString()
			=> $"BlackboardKey (Key: {m_Key}, Hash: {m_Hash})";
	}

	// --------------------------------------------------------------------------------
	// --------------------------------------------------------------------------------

#if UNITY_EDITOR

	[CustomPropertyDrawer(typeof(BlackboardKey))]
	public class BlackboardKeyPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var indent = EditorGUI.indentLevel;
			EditorGUI.indentLevel = 0;

			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

			var keyRect = new Rect(position.x, position.y, position.width * 0.6f, position.height);
			var keyProperty = property.FindPropertyRelative("m_Key");
			EditorGUI.PropertyField(keyRect, keyProperty, GUIContent.none);

			var hashRect = new Rect(position.x + position.width * 0.65f, position.y, position.width * 0.35f, position.height);
			var hashProperty = property.FindPropertyRelative("m_Hash");
			hashProperty.intValue = keyProperty.stringValue.GetHashCode();
			EditorGUI.LabelField(hashRect, new GUIContent($"{hashProperty.intValue}"), new GUIStyle() { fontStyle = FontStyle.Italic });

			EditorGUI.indentLevel = indent;
		}
	}

#endif // UNITY_EDITOR
}