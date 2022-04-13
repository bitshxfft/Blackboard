#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(char))]
	public class CharInspector
	{
		public static object Inspect(object charObject)
			=> (char)UnityEngine.Mathf.Clamp(UnityEditor.EditorGUILayout.IntField((char)charObject), char.MinValue, char.MaxValue);
	}
}

#endif // UNITY_EDITOR