#if UNITY_EDITOR

namespace BitwiseAI.Editor
{
	[BlackboardPropertyInspector(typeof(byte))]
	public class ByteInspector
	{
		public static object Inspect(object byteObject)
			=> (byte)UnityEngine.Mathf.Clamp(UnityEditor.EditorGUILayout.IntField((byte)byteObject), byte.MinValue, byte.MaxValue);
	}
}

#endif // UNITY_EDITOR