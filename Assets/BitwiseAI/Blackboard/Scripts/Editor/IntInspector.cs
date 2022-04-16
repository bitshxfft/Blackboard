#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(int))]
	public class IntInspector
	{
		public static object Inspect(object intObject)
			=> UnityEditor.EditorGUILayout.IntField((int)intObject);
	}
}

#endif // UNITY_EDITOR