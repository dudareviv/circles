﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CommonGameEvent<T>
{
	private readonly List<Action<T>> _callbacks = new List<Action<T>>(); 
	
	public void Subscribe(Action<T> callback)
	{
		_callbacks.Add(callback);
	}
	
	public void Publish(T obj)
	{
		foreach (Action<T> callback in _callbacks) {
			callback (obj);
		}
	}
}
