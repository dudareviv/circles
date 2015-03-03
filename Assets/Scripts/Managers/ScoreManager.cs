using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	// Общий счет
	public int scores = 0;

	// Коэффициент на один шарик
	public int scoresCoefficient = 10;
	
	public Text scoresText;

	public void Awake()
	{
        EventManager.MonsterPoof.Subscribe(OnPoof);
	}

	/**
	 * Обновляет счет.
	 */
	private void OnPoof(Monster monster)
	{
        scores += CalculateScores(monster);
		scoresText.text = scores.ToString();
	}

	/**
	 * Производит расчет стоимости объекта.
	 */
    private int CalculateScores(Monster monster)
    {
        return Mathf.CeilToInt(1f / monster.gameObject.transform.localScale.x * scoresCoefficient);
	}
}
