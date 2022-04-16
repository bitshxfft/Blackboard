namespace BitwiseAI
{
	public readonly struct BlackboardIndex
	{
		public int TypeIndex { get; }
		public int ValueIndex { get; }

		// ----------------------------------------------------------------------------

		public BlackboardIndex(int typeIndex, int valueIndex)
		{
			TypeIndex = typeIndex;
			ValueIndex = valueIndex;
		}
	}
}