using UnityEngine;
using System.Collections;

public class ColorHelper
{
	/**
	 * Возвращает случайны цвет, 
	 * при этом один из каналов будет равен 255, 
	 * а второй случайной величине между 0 и 255.
	 */
	public static Color GetRandomColor(){
		Color color = new Color ();
		color.a = 1f;

		int first = Random.Range (0, 2);
		int offset = Random.Range (1, 2);
		int second = (first + offset) % 3;
		float channel = Random.Range (0f, 1f);

		switch (first) {
		case 0:
			color.r = 1f;
			break;
		case 1:
			color.g = 1f;
			break;
		case 2:
			color.b = 1f;
			break;
		}

		switch (second) {
		case 0:
			color.r = channel;
			break;
		case 1:
			color.g = channel;
			break;
		case 2:
			color.b = channel;
			break;
		}

		return color;
	}
}
