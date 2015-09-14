﻿using UnityEngine;

public class ComboCounter
{
	public static float CurrentTime { get { return Time.fixedTime; } }

	public System.Action onBegin;
	public System.Action<int> onIncrease;
	public System.Action<int> onEnd;

	public float Duration = 1.0f;
	private int m_count;
	private float m_lastRecordTime;
	public void Record()
	{
		if (0 == m_count)
		{
			OnBegin();
		}
		m_lastRecordTime = CurrentTime;
		m_count++;
		OnIncrease(m_count);
	}
	public void FixedUpdate()
	{
		if (0 == m_count)
		{
			return;
		}
		if (CurrentTime - m_lastRecordTime > Duration)
		{
			OnEnd(m_count);
			m_count = 0;
			m_lastRecordTime = 0.0f;
		}
	}
	private void OnBegin()
	{
		if (null != onBegin)
		{
			onBegin();
		}
	}
	private void OnIncrease(int current)
	{
		if (null != onIncrease)
		{
			onIncrease(current);
		}
	}
	private void OnEnd(int current)
	{
		if (null != onEnd)
		{
			onEnd(current);
		}
	}
}
