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
			Assert.True(accessor1.TypeIndex == 0);
			Assert.True(accessor1.ValueIndex == 0);
			
			var accessor2 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test 2"));
			Assert.True(accessor2.TypeIndex == 0);
			Assert.True(accessor2.ValueIndex == 1);
			
			var accessor3 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test 3"));
			Assert.True(accessor3.TypeIndex == 0); 
			Assert.True(accessor3.ValueIndex == 2);
		}

		[Test]
		public void MultiKeyAccessorTest()
		{
			var blackboard = new Blackboard();
			var accessor1 = blackboard.CreateAccessor<int>(new BlackboardKey("Int Test"));
			Assert.True(accessor1.TypeIndex == 0);
			Assert.True(accessor1.ValueIndex == 0);
			
			var accessor2 = blackboard.CreateAccessor<float>(new BlackboardKey("Float Test"));
			Assert.True(accessor2.TypeIndex == 1);
			Assert.True(accessor2.ValueIndex == 0);
			
			var accessor3 = blackboard.CreateAccessor<object>(new BlackboardKey("Object 1 Test"));
			Assert.True(accessor3.TypeIndex == 2);
			Assert.True(accessor3.ValueIndex == 0);
			
			var accessor4 = blackboard.CreateAccessor<object>(new BlackboardKey("Object 2 Test"));
			Assert.True(accessor4.TypeIndex == 2);
			Assert.True(accessor4.ValueIndex == 1);
			
			var accessor5 = blackboard.CreateAccessor<object>(new BlackboardKey("Object 3 Test"));
			Assert.True(accessor5.TypeIndex == 2);
			Assert.True(accessor5.ValueIndex == 2);
		}

		[Test]
		public void IntTest()
		{
			var originalValue = 123;
			var blackboard = new Blackboard();
			var key = new BlackboardKey("Int Test");
			blackboard.Set(key, originalValue);
			var accessedValue = blackboard.Get<int>(key);
			Assert.True(originalValue == accessedValue);
		}

		[Test]
		public void MultiIntTest()
		{
			var blackboard = new Blackboard();

			var originalValue1 = 123;
			var key1 = new BlackboardKey("Int Test 1");
			blackboard.Set(key1, originalValue1);
			var accessedValue1 = blackboard.Get<int>(key1);
			Assert.True(originalValue1 == accessedValue1);

			var originalValue2 = int.MaxValue;
			var key2 = new BlackboardKey("Int Test 2");
			blackboard.Set(key2, originalValue2);
			var accessedValue2 = blackboard.Get<int>(key2);
			Assert.True(originalValue2 == accessedValue2);

			var originalValue3 = int.MinValue;
			var key3 = new BlackboardKey("Int Test 3");
			blackboard.Set(key3, originalValue3);
			var accessedValue3 = blackboard.Get<int>(key3);
			Assert.True(originalValue3 == accessedValue3);

			var originalValue4 = -123456789;
			var key4 = new BlackboardKey("Int Test 4");
			blackboard.Set(key4, originalValue4);
			var accessedValue4 = blackboard.Get<int>(key4);
			Assert.True(originalValue4 == accessedValue4);
		}

		[Test]
		public void InvalidKeyTest()
		{
			var originalValue = 123;

			var correctKey = new BlackboardKey("IntKey");
			var incorrectKey = new BlackboardKey("FailKey");

			var blackboard = new Blackboard();
			blackboard.Set(correctKey, originalValue);

			var accessedValue = blackboard.Get<int>(incorrectKey);
			Assert.False(originalValue == accessedValue);
			Assert.True(accessedValue == default);
		}

		[Test]
		public void InvalidAccessorTest()
		{
			var originalValue = 123;
			var key = new BlackboardKey("IntKey");

			var blackboard = new Blackboard();
			var validAccessor = blackboard.CreateAccessor<int>(key);
			blackboard.Set(validAccessor, originalValue);
			
			var invalidTypeAccessor = new BlackboardIndex(validAccessor.TypeIndex + 1, validAccessor.ValueIndex);
			Assert.Throws<System.ArgumentOutOfRangeException>(() => { blackboard.Get<int>(invalidTypeAccessor); });

			var invalidValueAccessor = new BlackboardIndex(validAccessor.TypeIndex, validAccessor.ValueIndex + 1);
			Assert.Throws<System.ArgumentOutOfRangeException>(() => { blackboard.Get<int>(invalidValueAccessor); });
		}
	}
}