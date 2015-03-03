using UnityEngine;
using System.Collections;

/**
 * Менеджер 
 */
public class DestroyManager : MonoBehaviour 
{
	void Start () {
		Vector2 cameraSize = CameraHelper.GetCameraBounds ();

		BoxCollider2D collider = GetComponent<BoxCollider2D>();
		
		collider.size = new Vector2 (cameraSize.x, 1f);

		transform.position = new Vector2 (0, -(cameraSize.y / 2f + collider.size.y + SpawnManager.Instance.scaleMax));

		EventManager.TouchBegan.Subscribe (OnTouchBegan);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Destroy (other.gameObject);
	}

	/**
	 * Уничтожаем объекты в радиусе прикосновения.
	 */
	void OnTouchBegan(Vector3 touchPosition){
		Collider2D[] colliders = Physics2D.OverlapCircleAll (touchPosition, 0.2f);

		foreach (Collider2D collider in colliders) {
			collider.SendMessage("Poof");
		}
	}
}
