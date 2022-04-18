#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Transform))]
	public class TransformInspector
	{
		public static object Inspect(object transformObject)
			=> UnityEditor.EditorGUILayout.ObjectField((UnityEngine.Transform)transformObject, typeof(UnityEngine.Transform), true);
	}
}

#endif // UNITY_EDITOR