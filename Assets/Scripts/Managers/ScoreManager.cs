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
		EventManager.CirclePoof.Subscribe(OnPoof);
	}

	/**
	 * Обновляет счет.
	 */
	private void OnPoof(Circle circle)
	{
		scores += CalculateScores(circle);
		scoresText.text = scores.ToString();
	}

	/**
	 * Производит расчет стоимости объекта.
	 */
	private int CalculateScores(Circle circle){
		return Mathf.CeilToInt(1f / circle.gameObject.transform.localScale.x * scoresCoefficient);
	}
}
