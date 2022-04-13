#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(short))]
	public class ShortInspector
	{
		public static object Inspect(object shortObject)
			=> (short)UnityEngine.Mathf.Clamp(UnityEditor.EditorGUILayout.IntField((short)shortObject), short.MinValue, short.MaxValue);
	}
}

#endif // UNITY_EDITOR