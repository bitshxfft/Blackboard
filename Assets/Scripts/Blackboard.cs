using System;
using System.Collections;
using System.Collections.Generic;

namespace AI
{
	[Serializable]
	public class Blackboard
	{
		private Dictionary<Type, int> m_TypeIndices = new Dictionary<Type, int>();
		private List<Dictionary<int, int>> m_valueIndices = new List<Dictionary<int, int>>();
		private List<IList> m_Values = new List<IList>();

		// ----------------------------------------------------------------------------

		private int AddType<T>()
		{
			var type = typeof(T);
			if (false == m_TypeIndices.TryGetValue(type, out int typeIndex))
			{
				typeIndex = m_valueIndices.Count;
				m_TypeIndices.Add(type, typeIndex);

				var values = new List<T>();
				m_Values.Add((IList)values);
				m_valueIndices.Add(new Dictionary<int, int>());
			}

			return typeIndex;
		}

		// ----------------------------------------------------------------------------

		public BlackboardIndex CreateAccessor<T>(in BlackboardKey key)
		{
			if (false == m_TypeIndices.TryGetValue(typeof(T), out int typeIndex))
			{
				typeIndex = AddType<T>();
			}

			if (false == m_valueIndices[typeIndex].TryGetValue(key.Hash, out int valueIndex))
			{
				var values = (List<T>)m_Values[typeIndex];
				valueIndex = values.Count;
				values.Add(default(T));

				var valueIndices = m_valueIndices[typeIndex];
				valueIndices.Add(key.Hash, valueIndex);
			}

			return new BlackboardIndex(typeIndex, valueIndex);
		}

		public T Get<T>(in BlackboardKey key)
		{
			var index = CreateAccessor<T>(key);
			var values = (List<T>)m_Values[index.TypeIndex];
			return values[index.ValueIndex];
		}

		public void Set<T>(in BlackboardKey key, T value)
		{
			var index = CreateAccessor<T>(key); 
			var values = (List<T>)m_Values[index.TypeIndex];
			values[index.ValueIndex] = value;
		}

		public T Get<T>(in BlackboardIndex index)
		{
			var values = (List<T>)m_Values[index.TypeIndex];
			return values[index.ValueIndex];
		}

		public void Set<T>(in BlackboardIndex index, T value)
		{
			var values = (List<T>)m_Values[index.TypeIndex];
			values[index.ValueIndex] = value;
		}
	}
}