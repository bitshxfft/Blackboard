using System;
using System.Collections;
using System.Collections.Generic;

namespace BitwiseAI.Blackboard
{
	[Serializable]
	public class Blackboard
	{
		public struct KeyData
		{
			public readonly BlackboardKey m_Key;
			public readonly Type m_Type;

			public KeyData(BlackboardKey key, Type type)
			{
				m_Key = key;
				m_Type = type;
			}
		}

		// ----------------------------------------------------------------------------

		private Dictionary<Type, int> m_TypeIndices = new Dictionary<Type, int>();
		private List<Dictionary<int, int>> m_valueIndices = new List<Dictionary<int, int>>();
		private List<IList> m_Values = new List<IList>();
		private List<KeyData> m_AllKeys = new List<KeyData>();

		// ----------------------------------------------------------------------------

		private int AddType<T>()
		{
			var type = typeof(T);
			if (false == m_TypeIndices.TryGetValue(type, out int typeIndex))
			{
				typeIndex = m_valueIndices.Count;
				m_TypeIndices.Add(type, typeIndex);

				var values = new List<T>();
				m_Values.Add(values);
				m_valueIndices.Add(new Dictionary<int, int>());
			}

			return typeIndex;
		}

		public BlackboardIndex CreateAccessor<T>(in BlackboardKey key)
		{
			var type = typeof(T);
			if (false == m_TypeIndices.TryGetValue(type, out int typeIndex))
			{
				typeIndex = AddType<T>();
			}

			var hash = key.Hash;
			if (false == m_valueIndices[typeIndex].TryGetValue(hash, out int valueIndex))
			{
				var values = (List<T>)m_Values[typeIndex];
				valueIndex = values.Count;
				values.Add(default(T));

				var valueIndices = m_valueIndices[typeIndex];
				valueIndices.Add(hash, valueIndex);

				OnKeyUsed<T>(key);
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

		public T QuickGet<T>(in BlackboardIndex index)
		{
			var values = (List<T>)m_Values[index.TypeIndex];
			return values[index.ValueIndex];
		}

		public void QuickSet<T>(in BlackboardIndex index, T value)
		{
			var values = (List<T>)m_Values[index.TypeIndex];
			values[index.ValueIndex] = value;
		}

		public IReadOnlyList<KeyData> GetKeyDatas()
			=> m_AllKeys;

		private void OnKeyUsed<T>(in BlackboardKey key)
		{
			var type = typeof(T);
			var hash = key.Hash;

			bool keyDataExists = false;
			for (int k = 0; k < m_AllKeys.Count; ++k)
			{
				var keyData = m_AllKeys[k];
				if (keyData.m_Key.Hash == hash
					&& keyData.m_Type == type)
				{
					keyDataExists = true;
					break;
				}
			}

			if (false == keyDataExists)
			{
				m_AllKeys.Add(new KeyData(key, type));
			}
		}
	}
}