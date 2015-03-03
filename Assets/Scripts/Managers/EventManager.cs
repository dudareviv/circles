using UnityEngine;
using System.Collections;

public class EventManager
{
    public static CommonGameEvent<Circle> CirclePoof = new CommonGameEvent<Circle>();
    public static CommonGameEvent<Monster> MonsterPoof = new CommonGameEvent<Monster>();
	public static CommonGameEvent<Vector3> TouchBegan = new CommonGameEvent<Vector3>();
	public static CommonGameEvent<Vector3> TouchMoved = new CommonGameEvent<Vector3>();
	public static CommonGameEvent<Vector3> TouchEnded = new CommonGameEvent<Vector3>();
}
