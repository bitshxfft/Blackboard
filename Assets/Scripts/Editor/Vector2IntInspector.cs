#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Vector2Int))]
	public class Vector2IntInspector
	{
		public static object Inspect(object vector2IntObject)
			=> UnityEditor.EditorGUILayout.Vector2IntField("", (UnityEngine.Vector2Int)vector2IntObject);
	}
}

#endif // UNITY_EDITOR