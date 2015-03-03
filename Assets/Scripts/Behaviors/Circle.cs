using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
	/**
	 * Задает цвет для спрайта.
	 */
	void SetColor (Color color) {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = color;
	}

	/**
	 * Уничтожает объект и сообщаем об этом.
	 */
	void Poof(){
		EventManager.CirclePoof.Publish (this);
		Destroy (gameObject);
	}
}
