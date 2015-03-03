using UnityEngine;
using System.Collections;

public class TopDownMove : MonoBehaviour 
{
	// Скорость объекта
	public float speed = 1f;

	void Update () {
		Move ();
	}

	/**
	 * Перемещает объект с определенной скоростью в направлении вниз.
	 */
	public void Move(){
		transform.position = Vector3.MoveTowards (transform.position, transform.position + Vector3.down, speed * Time.deltaTime);
	}

	/**
	 * Задает скорость.
	 */
	public void SetSpeed(float value){
		speed = value;
	}
}