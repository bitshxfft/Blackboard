#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Vector3Int))]
	public class Vector3IntInspector
	{
		public static object Inspect(object vector3IntObject)
			=> UnityEditor.EditorGUILayout.Vector3IntField("", (UnityEngine.Vector3Int)vector3IntObject);
	}
}

#endif // UNITY_EDITOR