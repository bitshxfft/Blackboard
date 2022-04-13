#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(float))]
	public class FloatInspector
	{
		public static object Inspect(object floatObject)
			=> UnityEditor.EditorGUILayout.FloatField((float)floatObject);
	}
}

#endif // UNITY_EDITOR