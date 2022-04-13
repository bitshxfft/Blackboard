#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Vector4))]
	public class Vector4Inspector
	{
		public static object Inspect(object vector4Object)
			=> UnityEditor.EditorGUILayout.Vector4Field("", (UnityEngine.Vector4)vector4Object);
	}
}

#endif // UNITY_EDITOR