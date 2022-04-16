#if UNITY_EDITOR

using System;

namespace BitwiseAI.Blackboard.Editor
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class BlackboardPropertyInspectorAttribute : Attribute
	{
		public Type m_PropertyType;

		// ----------------------------------------------------------------------------

		public BlackboardPropertyInspectorAttribute(Type propertyType)
		{
			m_PropertyType = propertyType;
		}
	}
}

#endif // UNITY_EDITOR