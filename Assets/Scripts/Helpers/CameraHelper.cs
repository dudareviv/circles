using UnityEngine;
using System.Collections;

public class CameraHelper 
{
	/**
	 * Рассчитывает границы контейнера камеры.
	 */
	public static Vector2 GetCameraBounds(){
		Vector3 size = new Vector3 ();

		size.x = Camera.main.orthographicSize * Screen.width / Screen.height;
		size.y = Camera.main.orthographicSize;
		size *= 2f;

		return size;
	}
}
