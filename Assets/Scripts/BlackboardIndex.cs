namespace AI
{
	public readonly struct BlackboardIndex
	{
		public readonly int TypeIndex { get; }
		public readonly int ValueIndex { get; }

		// ----------------------------------------------------------------------------

		public BlackboardIndex(int typeIndex, int valueIndex)
		{
			TypeIndex = typeIndex;
			ValueIndex = valueIndex;
		}
	}
}