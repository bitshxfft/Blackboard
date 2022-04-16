using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using BitwiseAI.Blackboard.Editor;
#endif // UNITY_EDITOR

namespace BitwiseAI.Blackboard
{
	public class BlackboardComponent : MonoBehaviour
	{
		private Blackboard m_Blackboard = new Blackboard();
		public Blackboard Blackboard => m_Blackboard;

		// ----------------------------------------------------------------------------

#if UNITY_EDITOR

		[BlackboardPropertyInspector(typeof(BlackboardComponent))]
		public class ObjectInspector
		{
			public static object Inspect(object obj)
				=> EditorGUILayout.ObjectField((Object)obj, obj.GetType(), false);
		}

		[CustomEditor(typeof(BlackboardComponent))]
		public class BehaviourTreeRunnerComponentEditor : UnityEditor.Editor
		{
			public override void OnInspectorGUI()
			{
				DrawDefaultInspector();
				EditorGUILayout.Space();

				EditorGUILayout.BeginHorizontal();
				{
					EditorGUI.BeginDisabledGroup(false == EditorApplication.isPlaying);
					{
						var runner = (BlackboardComponent)target;
						if (GUILayout.Button("View Blackboard"))
						{
							BlackboardEditor.Open(runner.Blackboard);
						}
					}
					EditorGUI.EndDisabledGroup();
				}
				EditorGUILayout.EndHorizontal();
			}
		}

#endif // UNITY_EDITOR
	}
}
