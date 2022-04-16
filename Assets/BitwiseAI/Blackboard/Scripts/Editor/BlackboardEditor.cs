#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace BitwiseAI.Blackboard.Editor
{
	public class BlackboardEditor : EditorWindow
	{
		private static BlackboardEditor s_ActiveWindow = null;
		private Blackboard m_Blackboard = null;
		private Dictionary<Type, Type> m_Inspectors = null;
		private Vector2 m_ScrollOffset = Vector2.zero;

		// ----------------------------------------------------------------------------

		public static void Open(Blackboard blackboard)
		{
			// close window if it's open
			if (null != s_ActiveWindow)
			{
				s_ActiveWindow.Close();
				s_ActiveWindow = null;
			}

			// open a new window and bind blackboard
			if (null == s_ActiveWindow)
			{
				s_ActiveWindow = CreateWindow<BlackboardEditor>();
				s_ActiveWindow.minSize = new Vector2(100.0f, 100.0f);
				s_ActiveWindow.m_Blackboard = blackboard;
				s_ActiveWindow.PopulateInspectors();
			}
		}

		private void PopulateInspectors()
		{
			if (null == m_Inspectors)
			{
				m_Inspectors = new Dictionary<Type, Type>();

				var assemblies = AppDomain.CurrentDomain.GetAssemblies();
				foreach (var assembly in assemblies)
				{
					foreach (var type in assembly.GetTypes())
					{
						var attribute = type.GetCustomAttribute<BlackboardPropertyInspectorAttribute>();
						if (null != attribute)
						{
							m_Inspectors.Add(attribute.m_PropertyType, type);
						}
					}
				}
			}
		}

		private void OnInspectorUpdate()
		{
			Repaint();
		}

		private void OnGUI()
		{
			Draw();
		}

		private void OnDestroy()
		{
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
			s_ActiveWindow = null;
		}

		// ----------------------------------------------------------------------------

		private void Draw()
		{
			var textColour = new Color(0.9f, 0.9f, 0.9f);
			var headerStyle = new GUIStyle
			{
				alignment = TextAnchor.UpperCenter,
				normal = new GUIStyleState { textColor = textColour },
				fontStyle = FontStyle.Bold,
				fontSize = 16,
			};

			var keyStyle = new GUIStyle
			{
				normal = new GUIStyleState { textColor = textColour },
				fontSize = 12,
			};

			if (null != m_Blackboard)
			{
				EditorGUILayout.LabelField("Blackboard", headerStyle);
				EditorGUILayout.Space();

				m_ScrollOffset = EditorGUILayout.BeginScrollView(m_ScrollOffset);
				{
					var keyDatas = new List<Blackboard.KeyData>(m_Blackboard.GetKeyDatas());
					keyDatas.Sort((a, b) => { return a.m_Key.Key.CompareTo(b.m_Key.Key); });

					for (int k = 0; k < keyDatas.Count; ++k)
					{
						var keyData = keyDatas[k];
						var key = keyData.m_Key;
						var type = keyData.m_Type;

						EditorGUILayout.BeginHorizontal("Box");
						{
							EditorGUILayout.LabelField($"{key.Key}", keyStyle);
							EditorGUI.indentLevel += 1;

							// get value from Blackboard using the Blackboard's Get(BlackboardKey) method
							MethodInfo getMethod = typeof(Blackboard).GetMethod("Get");
							MethodInfo genericGetMethod = getMethod.MakeGenericMethod(type);
							var parameters = new object[] { key };
							var original = genericGetMethod.Invoke(m_Blackboard, parameters);

							// get inspector if we have one
							if (m_Inspectors.TryGetValue(type, out Type inspectorType) && null != inspectorType)
							{
								// get the inspector's Inspect method
								MethodInfo inspectMethod = inspectorType.GetMethod("Inspect");
								if (null != inspectMethod)
								{
									EditorGUILayout.BeginVertical();
									var inspectedValue = inspectMethod.Invoke(null, new[] { original }) ?? original;
									EditorGUILayout.EndVertical();

									if (inspectedValue != original)
									{
										// set value on Blackboard using the Blackboard's Set(BlackboardKey) method
										MethodInfo setMethod = typeof(Blackboard).GetMethod("Set");
										MethodInfo genericSetMethod = setMethod.MakeGenericMethod(type);
										genericSetMethod.Invoke(m_Blackboard, new object[] { key, inspectedValue });
									}
								}
								else
								{
									OnFailedToInspect();
								}
							}
							else
							{
								OnFailedToInspect();
							}

							void OnFailedToInspect()
							{
								EditorGUILayout.LabelField($"Unable to inspect {keyData.m_Type}, " +
									$"requires a custom inspector with the BlackboardPropertyInspector<{keyData.m_Type}> attribute and an Inspect method. " +
									$"See documentation for more details.",
									new GUIStyle(GUI.skin.box) { fontStyle = FontStyle.Italic });
							}

							EditorGUI.indentLevel -= 1;
						}
						EditorGUILayout.EndHorizontal();
					}
				}
				EditorGUILayout.EndScrollView();
			}
			else
			{
				EditorGUILayout.LabelField("No Blackboard selected", headerStyle);
			}
		}
	}
}

#endif // UNITY_EDITOR