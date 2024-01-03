using UnityEngine;

public static class ColorExtensions {

	private const int UPSCALE_FACTOR = 255;
	private const int RED_BITSHIFT = 16;
	private const int GREEN_BITSHIFT = 8;

	public static int GetRgbInteger(this Color color)
	{
		int upscaledR = Mathf.CeilToInt(color.r * UPSCALE_FACTOR);
		int upscaledG = Mathf.CeilToInt(color.g * UPSCALE_FACTOR);
		int upscaledB = Mathf.CeilToInt(color.b * UPSCALE_FACTOR);
		return (upscaledR << RED_BITSHIFT) | (upscaledG << GREEN_BITSHIFT) | (upscaledB);
	}
}
