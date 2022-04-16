#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(ushort))]
	public class UshortInspector
	{
		public static object Inspect(object ushortObject)
			=> (ushort)UnityEngine.Mathf.Clamp(UnityEditor.EditorGUILayout.IntField((ushort)ushortObject), ushort.MinValue, ushort.MaxValue);
	}
}

#endif // UNITY_EDITOR