using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour
{
    public GameObject Body;
    public GameObject Eyes;
    public GameObject Mouth;

    public SpriteRenderer BodyRenderer;
    public SpriteRenderer EyesRenderer;
    public SpriteRenderer MouthRenderer;

    public float BodyMinScale = 0.5f;
    public float BodyMaxScale = 1.5f;

    public float EyesMinScale = 1f;
    public float EyesMaxScale = 2f;

    public float EyesAngle = 10f;

    public float MouthMinScale = 0.8f;
    public float MouthMaxScale = 1f;

    public float MouthAngle = 10f;

    public void SetRandomAll()
    {
        SetRandomBody();
        SetRandomEyes();
        SetRandomMouth();
    }

    public void SetRandomBody()
    {
        SetRandomBodySprite();
        SetRandomBodyScale();
        SetRandomBodyColor();
    }

    public void SetRandomBodySprite()
    {
        BodyRenderer.sprite = ResourcesManager.Instance.GetRandom(ResourcesManager.Instance.Bodies);
    }

    public void SetRandomBodyScale()
    {
        Body.transform.localScale = new Vector3(Random.Range(BodyMinScale, BodyMaxScale), Random.Range(BodyMinScale, BodyMaxScale), 1);
    }

    public void SetRandomBodyColor()
    {
        BodyRenderer.color = ColorHelper.GetRandomColor();
    }

    public void SetRandomEyes()
    {
        SetRandomEyesSprite();
        SetRandomEyesScale();
        SetRandomEyesPosition();
        SetRandomEyesAngle();
    }

    public void SetRandomEyesSprite()
    {
        EyesRenderer.sprite = ResourcesManager.Instance.GetRandom(ResourcesManager.Instance.Eyes);
    }

    public void SetRandomEyesScale()
    {
        Eyes.transform.localScale = new Vector3(Random.Range(EyesMinScale, EyesMaxScale), Random.Range(EyesMinScale, EyesMaxScale), 1);
    }

    public void SetRandomEyesPosition()
    {
        var dY = BodyRenderer.sprite.bounds.size.y*Body.transform.localScale.y/2f;
        Eyes.transform.localPosition = new Vector3(0f, Random.Range(0, dY), 0f);
    }

    public void SetRandomEyesAngle()
    {
        Eyes.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-EyesAngle, EyesAngle));
    }

    public void SetRandomMouth()
    {
        SetRandomMouthSprite();
        SetRandomMouthScale();
        SetRandomMouthPosition();
        SetRandomMouthAngle();
    }

    public void SetRandomMouthSprite()
    {
        MouthRenderer.sprite = ResourcesManager.Instance.GetRandom(ResourcesManager.Instance.Mouths);
    }

    public void SetRandomMouthScale()
    {
        Mouth.transform.localScale = new Vector3(Random.Range(MouthMinScale, MouthMaxScale), Random.Range(MouthMinScale, MouthMaxScale), 1);
    }

    public void SetRandomMouthPosition()
    {
        var dY = BodyRenderer.sprite.bounds.size.y * Body.transform.localScale.y / 2f - MouthRenderer.sprite.bounds.size.y;
        var dX = BodyRenderer.sprite.bounds.size.x * Body.transform.localScale.x / 2f - MouthRenderer.sprite.bounds.size.x;

        Mouth.transform.localPosition = new Vector3(Random.Range(-dX, dX), Random.Range(-dY, 0), 0f);
    }

    public void SetRandomMouthAngle()
    {
        Mouth.transform.localEulerAngles = new Vector3(0, 0, Random.Range(-MouthAngle, MouthAngle));
    }

    /**
     * Уничтожает объект и сообщаем об этом.
     */
    void Poof()
    {
        EventManager.MonsterPoof.Publish(this);
        Destroy(gameObject);
    }
}