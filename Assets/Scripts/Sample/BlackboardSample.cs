using UnityEngine;

namespace BitwiseAI
{
	public class BlackboardSample : MonoBehaviour
	{
		private void Start()
		{
			var blackboardComponent = gameObject.GetComponent<BlackboardComponent>();
			if (null != blackboardComponent)
			{
				blackboardComponent.Blackboard.Set(new BlackboardKey("int value"), 123);
				blackboardComponent.Blackboard.Set(new BlackboardKey("int value2"), 456);
				blackboardComponent.Blackboard.Set(new BlackboardKey("int value3"), 789);
				blackboardComponent.Blackboard.Set(new BlackboardKey("char value"), (char)123);
				blackboardComponent.Blackboard.Set(new BlackboardKey("short value"), (short)123);
				blackboardComponent.Blackboard.Set(new BlackboardKey("ushort value"), (ushort)123);
				blackboardComponent.Blackboard.Set(new BlackboardKey("BlackboardComponent value"), blackboardComponent);
				blackboardComponent.Blackboard.Set(new BlackboardKey("string value"), "Test string");
				blackboardComponent.Blackboard.Set(new BlackboardKey("Blackboard Key value"), new BlackboardKey("Inner key"));
				blackboardComponent.Blackboard.Set(new BlackboardKey("Vector2 value"), new Vector2(123.4f, 567.89f));
				blackboardComponent.Blackboard.Set(new BlackboardKey("Vector3 value"), new Vector3(12.3f, 45.6f, 78.9f));
				blackboardComponent.Blackboard.Set(new BlackboardKey("Vector2Int value"), new Vector2Int(123, 456));
			}
		}
	}
}
