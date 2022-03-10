using System;
using System.Globalization;
using NUnit.Framework;
using UnityEngine;
using AI;

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
	}
}