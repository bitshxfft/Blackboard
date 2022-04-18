#if UNITY_EDITOR

namespace BitwiseAI.Blackboard.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.GameObject))]
	public class GameObjectInspector
	{
		public static object Inspect(object gameObject)
			=> UnityEditor.EditorGUILayout.ObjectField((UnityEngine.GameObject)gameObject, typeof(UnityEngine.GameObject), true);
	}
}

#endif // UNITY_EDITOR