#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Transform))]
	public class TransformInspector
	{
		public static object Inspect(object transformObject)
			=> UnityEditor.EditorGUILayout.ObjectField((UnityEngine.Object)transformObject, transformObject.GetType(), true);
	}
}

#endif // UNITY_EDITOR