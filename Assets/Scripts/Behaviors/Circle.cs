using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
	void SetColor (Color color) {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = color;
	}

	void OnMouseDown() {
		Debug.Log ("Clicked");
		Poof ();
	}

	void Poof(){
		EventManager.CirclePoof.Publish (this);
		Destroy (gameObject);
	}
}
