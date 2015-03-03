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
    private Vector2 cameraContainerSize;

    private void Start()
    {
        InitCameraSize();
        StartSpawnInvoke();
    }

    /**
	 * Инициализирует размеры контейнера камеры.
	 */

    private void InitCameraSize()
    {
        cameraContainerSize = CameraHelper.GetCameraBounds();
    }

    private void SpawnLoop()
    {
        Spawn();
        StartSpawnInvoke();
    }

    /*
	 * Запускает отложенное выполнение метода SpawnLoop через случайный промежуток времени.
	 */

    private void StartSpawnInvoke()
    {
        Invoke("SpawnLoop", Random.Range(minCooldown, maxCooldown));
    }

    /**
	 * Создает объект из префаба и размещает его над экраном так, 
	 * чтобы он не выходил за его рамки по бокам и
	 * начинал свое движение так же за рамками экрана.
	 */

    private void Spawn()
    {
        GameObject go = (GameObject) GameObject.Instantiate(objectPrefab);

        float scale = Random.Range(scaleMin, scaleMax);

        go.transform.localScale = Vector3.one*scale;
        go.SendMessage("SetSpeed", speedBase/scale);
        go.SendMessage("SetRandomAll");

        var MonsterObject = go.GetComponent<Monster>();
        Vector2 spriteSize = MonsterObject.BodyRenderer.bounds.size;
        Vector2 objectScale = MonsterObject.Body.transform.localScale;

        float dX = (cameraContainerSize.x - spriteSize.x*objectScale.x)/2f;
        float y = (cameraContainerSize.y + spriteSize.y*objectScale.y)/2f;

        go.transform.position = new Vector2(Random.Range(-dX, dX), y);
    }
}