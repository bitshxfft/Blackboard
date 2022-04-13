using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using BitwiseAI.Editor;
#endif // UNITY_EDITOR

namespace BitwiseAI
{
	public class BlackboardComponent : MonoBehaviour
	{
		private Blackboard m_Blackboard;
		public Blackboard Blackboard => m_Blackboard;

		// ----------------------------------------------------------------------------

		private void Awake()
		{
			m_Blackboard = new Blackboard();

			m_Blackboard.Set(new BlackboardKey("Test int"), 123);
			m_Blackboard.Set(new BlackboardKey("Test char"), (char)123);
			m_Blackboard.Set(new BlackboardKey("Test short"), (short)123);
			m_Blackboard.Set(new BlackboardKey("Test ushort"), (ushort)123);
			m_Blackboard.Set(new BlackboardKey("Test BlackboardComponent"), this);
			m_Blackboard.Set(new BlackboardKey("Test string"), "Test string");
			m_Blackboard.Set(new BlackboardKey("Test Blackboard Key"), new BlackboardKey("Inner key"));
			m_Blackboard.Set(new BlackboardKey("Test Vector2"), new Vector2(123.4f, 567.89f));
			m_Blackboard.Set(new BlackboardKey("Test Vector3"), new Vector3(12.3f, 45.6f, 78.9f));
			m_Blackboard.Set(new BlackboardKey("Test Vector2Int"), new Vector2Int(123, 456));
		}

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
