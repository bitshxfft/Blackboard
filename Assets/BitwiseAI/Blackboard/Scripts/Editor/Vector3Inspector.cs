#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Vector3))]
	public class Vector3Inspector
	{
		public static object Inspect(object vector3Object)
			=> UnityEditor.EditorGUILayout.Vector3Field("", (UnityEngine.Vector3)vector3Object);
	}
}

#endif // UNITY_EDITOR