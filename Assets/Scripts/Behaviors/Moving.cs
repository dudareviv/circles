using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    // Скорость объекта
    public float Speed = 1f;

    private void Update()
    {
        Move();
    }

    /**
     * Перемещает объект с определенной скоростью в направлении вниз.
     */

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down,
            Speed*Time.deltaTime);
    }

    /**
     * Задает скорость.
     */

    public void SetSpeed(float value)
    {
        Speed = value;
    }
}