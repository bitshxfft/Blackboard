#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Vector2))]
	public class Vector2Inspector
	{
		public static object Inspect(object vector2Object)
			=> UnityEditor.EditorGUILayout.Vector2Field("", (UnityEngine.Vector2)vector2Object);
	}
}

#endif // UNITY_EDITOR