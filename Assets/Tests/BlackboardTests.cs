using NUnit.Framework;

namespace AI.Test
{
	public class BlackboardTest
	{
		[Test]
		public void IntAccessorTest()
		{
			var blackboard = new Blackboard();
			var accessor = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test"));
			Assert.True(accessor.TypeIndex == 0);
			Assert.True(accessor.ValueIndex == 0);
		}

		[Test]
		public void MultiIntAccessorTest()
		{
			var blackboard = new Blackboard();
			var accessor1 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test 1"));
			var accessor2 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test 2"));
			var accessor3 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test 3"));
			Assert.True(accessor1.TypeIndex == 0);
			Assert.True(accessor1.ValueIndex == 0);
			Assert.True(accessor2.ValueIndex == 1);
			Assert.True(accessor3.ValueIndex == 2);
		}

		[Test]
		public void MultiKeyAccessorTest()
		{
			var blackboard = new Blackboard();
			var accessor1 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test"));
			var accessor2 = blackboard.CreateAccessor<float>(new BlackboardKey("Float Test"));
			var accessor3 = blackboard.CreateAccessor<object>(new BlackboardKey("Object 1 Test"));
			var accessor4 = blackboard.CreateAccessor<object>(new BlackboardKey("Object 2 Test"));
			var accessor5 = blackboard.CreateAccessor<object>(new BlackboardKey("Object 3 Test"));
			Assert.True(accessor1.TypeIndex == 0);
			Assert.True(accessor1.ValueIndex == 0);
			Assert.True(accessor2.TypeIndex == 1);
			Assert.True(accessor2.ValueIndex == 0);
			Assert.True(accessor3.TypeIndex == 2);
			Assert.True(accessor3.ValueIndex == 0);
			Assert.True(accessor4.TypeIndex == 2);
			Assert.True(accessor4.ValueIndex == 1);
			Assert.True(accessor5.TypeIndex == 2);
			Assert.True(accessor5.ValueIndex == 2);
		}

		[Test]
		public void IntTest()
		{
			var originalValue = 123;
			var blackboard = new Blackboard();
			var key = new BlackboardKey("Int Test");
			blackboard.Set<int>(key, originalValue);
			var accessedValue = blackboard.Get<int>(key);
			Assert.True(originalValue == accessedValue);
		}

		[Test]
		public void MultiIntTest()
		{
			var originalValue1 = 123;
			var originalValue2 = int.MaxValue;
			var originalValue3 = int.MinValue;
			var originalValue4 = -123456789;

			var key1 = new BlackboardKey("Int Test 1");
			var key2 = new BlackboardKey("Int Test 2");
			var key3 = new BlackboardKey("Int Test 3");
			var key4 = new BlackboardKey("Int Test 4");

			var blackboard = new Blackboard();
			blackboard.Set<int>(key1, originalValue1);
			blackboard.Set<int>(key2, originalValue2);
			blackboard.Set<int>(key3, originalValue3);
			blackboard.Set<int>(key4, originalValue4);
			
			var accessedValue1 = blackboard.Get<int>(key1);
			Assert.True(originalValue1 == accessedValue1);

			var accessedValue2 = blackboard.Get<int>(key2);
			Assert.True(originalValue2 == accessedValue2);

			var accessedValue3 = blackboard.Get<int>(key3);
			Assert.True(originalValue3 == accessedValue3);

			var accessedValue4 = blackboard.Get<int>(key4);
			Assert.True(originalValue4 == accessedValue4);
		}
	}
}