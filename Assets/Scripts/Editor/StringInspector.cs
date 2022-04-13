#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(string))]
	public class StringInspector
	{
		public static object Inspect(object stringObject)
			=> UnityEditor.EditorGUILayout.TextField((string)stringObject);
	}
}

#endif // UNITY_EDITOR