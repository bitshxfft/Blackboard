using UnityEngine;

namespace BitwiseAI.Blackboard.Sample
{
	public class BlackboardSampleComponent : MonoBehaviour
	{
		[SerializeField] private BlackboardKey m_DeltaTimeKey = new BlackboardKey("DeltaTime");
		[SerializeField] private BlackboardKey m_FrameKey = new BlackboardKey("Frame");
		[SerializeField] private BlackboardKey m_TransformKey = new BlackboardKey("Transform Example");
		[SerializeField] private BlackboardKey m_GameObjectKey = new BlackboardKey("GameObject Example");
		[SerializeField] private BlackboardKey m_FrameDataStringKey = new BlackboardKey("String Example");

		// ----------------------------------------------------------------------------

		private Blackboard m_Blackboard = null;

		private BlackboardIndex m_DeltaTimeAccessor = default;
		private BlackboardIndex m_FrameAccessor = default;
		private BlackboardIndex m_TransformAccessor = default;
		private BlackboardIndex m_GameObjectAccessor = default;
		private BlackboardIndex m_FrameDataStringAccessor = default;

		// ----------------------------------------------------------------------------

		private void Start()
		{
			var blackboardComponent = transform.GetComponent<BlackboardComponent>();
			if (null == blackboardComponent)
			{
				Debug.LogError("[BitwiseAI.Blackboard.Sample.BlackboardSampleComponent :: Start] " +
					"Error - Unable to acquire Blackboard. Make sure this GameObject has a BlackboardComponent attached");
			}
			else
			{
				m_Blackboard = blackboardComponent.Blackboard;

				m_DeltaTimeAccessor = m_Blackboard.CreateAccessor<float>(m_DeltaTimeKey);
				m_FrameAccessor = m_Blackboard.CreateAccessor<int>(m_FrameKey);
				m_TransformAccessor = m_Blackboard.CreateAccessor<Transform>(m_TransformKey);
				m_GameObjectAccessor = m_Blackboard.CreateAccessor<GameObject>(m_GameObjectKey);
				m_FrameDataStringAccessor = m_Blackboard.CreateAccessor<string>(m_FrameDataStringKey);

				m_Blackboard.QuickSet(m_TransformAccessor, transform);
				m_Blackboard.QuickSet(m_GameObjectAccessor, gameObject);
			}
		}

		private void Update()
		{
			if (null != m_Blackboard)
			{
				// Every even frame update values using quick BlackboardIndex method.
				// Every odd frame update values using slow BlackboardKey method, incurring Dictionary lookups.
				if (Time.frameCount % 2 == 0)
				{
					m_Blackboard.QuickSet(m_DeltaTimeAccessor, Time.deltaTime);
					m_Blackboard.QuickSet(m_FrameAccessor, Time.frameCount);
					m_Blackboard.QuickSet(m_FrameDataStringAccessor, $"Time: {Time.time:0.00}, Frame {Time.frameCount}, Delta Time: {Time.deltaTime:0.000}");
				}
				else
				{
					m_Blackboard.Set(m_DeltaTimeKey, Time.deltaTime);
					m_Blackboard.Set(m_FrameKey, Time.frameCount);
					m_Blackboard.Set(m_FrameDataStringKey, $"Time: {Time.time:0.00}, Frame {Time.frameCount}, Delta Time: {Time.deltaTime:0.000}");
				}
			}
		}
	}
}
