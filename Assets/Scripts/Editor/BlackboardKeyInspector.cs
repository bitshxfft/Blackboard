#if UNITY_EDITOR

using UnityEditor;

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(BlackboardKey))]
	public class BlackboardKeyInspector
	{
		public static object Inspect(object keyObject)
		{
			var blackboardKey = (BlackboardKey)keyObject;
			var stringKey = EditorGUILayout.TextField(blackboardKey.Key);

			EditorGUI.BeginDisabledGroup(true);
			{
				EditorGUILayout.TextField(blackboardKey.ToString());
			}
			EditorGUI.EndDisabledGroup();

			return new BlackboardKey(stringKey);
		}
	}
}

#endif // UNITY_EDITOR