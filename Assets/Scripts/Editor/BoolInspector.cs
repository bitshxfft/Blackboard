#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(bool))]
	public class BoolInspector
	{
		public static object Inspect(object boolObject)
			=> UnityEditor.EditorGUILayout.Toggle((bool)boolObject);
	}
}

#endif // UNITY_EDITOR