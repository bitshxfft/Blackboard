#if UNITY_EDITOR

using System.Linq;
using System.Reflection;

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(System.Enum))]
	public class EnumInspector
	{
		public static object Inspect(object enumObject)
		{
			return enumObject.GetType().GetCustomAttributes<System.FlagsAttribute>(false).Any()
					? UnityEditor.EditorGUILayout.EnumFlagsField(enumObject as System.Enum)
					: UnityEditor.EditorGUILayout.EnumPopup(enumObject as System.Enum);
		}
	}
}

#endif // UNITY_EDITOR