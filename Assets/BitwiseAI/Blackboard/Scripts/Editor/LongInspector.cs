#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(long))]
	public class LongInspector
	{
		public static object Inspect(object longObject)
			=> UnityEditor.EditorGUILayout.LongField((long)longObject);
	}
}

#endif // UNITY_EDITOR