#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(uint))]
	public class UintInspector
	{
		public static object Inspect(object uintObject)
			=> (uint)UnityEngine.Mathf.Clamp(UnityEditor.EditorGUILayout.LongField((uint)uintObject), uint.MinValue, uint.MaxValue);
	}
}

#endif // UNITY_EDITOR