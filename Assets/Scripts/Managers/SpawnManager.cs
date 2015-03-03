using UnityEngine;
using System.Collections;

public class SpawnManager : Singleton<SpawnManager> 
{
	// Префаб объекта
	public GameObject objectPrefab;

	// Минимальный и максимальный размер объекта
	public float scaleMin = 0.5f;
	public float scaleMax = 1.5f;

	// Минимальный и максимальный перерыв между порождениями
	public float minCooldown = 0.1f;
	public float maxCooldown = 1f;

	// Базовая скорость объекта
	public float speedBase = 2f;

	// Размеры контейнера камеры
	Vector2 cameraContainerSize;

	void Start(){
		InitCameraSize ();
		StartSpawnInvoke ();
	}

	/**
	 * Инициализирует размеры контейнера камеры.
	 */
	private void InitCameraSize(){
		cameraContainerSize = CameraHelper.GetCameraBounds ();
	}
	
	private void SpawnLoop(){
		Spawn ();
		StartSpawnInvoke ();
	}

	/*
	 * Запускает отложенное выполнение метода SpawnLoop через случайный промежуток времени.
	 */
	private void StartSpawnInvoke(){
		Invoke("SpawnLoop", Random.Range(minCooldown, maxCooldown));
	}

	/**
	 * Создает объект из префаба и размещает его над экраном так, 
	 * чтобы он не выходил за его рамки по бокам и
	 * начинал свое движение так же за рамками экрана.
	 */
	private void Spawn(){
		GameObject go = (GameObject)GameObject.Instantiate(objectPrefab);

		float scale = Random.Range (scaleMin, scaleMax);
	
		Vector2 size = go.GetComponent<SpriteRenderer> ().bounds.size * scale;

		go.transform.localScale = Vector3.one * scale;
		go.SendMessage ("SetSpeed", speedBase / scale);
		go.SendMessage ("SetColor", ColorHelper.GetRandomColor());

		float dX = (cameraContainerSize.x - size.x) / 2f;
		float y = (cameraContainerSize.y + size.y) / 2f;

		go.transform.position = new Vector2 (Random.Range(-dX, dX), y);
	}
}