#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(UnityEngine.Color))]
	public class ColourInspector
	{
		public static object Inspect(object colourObject)
			=> UnityEditor.EditorGUILayout.ColorField("", (UnityEngine.Color)colourObject);
	}
}

#endif // UNITY_EDITOR