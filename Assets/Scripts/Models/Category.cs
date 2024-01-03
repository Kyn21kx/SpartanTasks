using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
public struct Category {
	
	#region Default Categories
	//Constant color declarations
	private static readonly Color MENTAL_BLUE_COLOR = new Color(10f / 255f, 210f / 255f, 255f / 255f);
	private static readonly Color PHYSICAL_RED_COLOR = new Color(252f / 255f, 0f / 255f, 63f / 255f);
	private static readonly Color LEAISURE_GREEN_COLOR = new Color(3f / 255f, 252f / 255f, 111f / 255f);
	private static readonly Color HOUSE_KEEPING_YELLOW_COLOR = new Color(242f / 255f, 234f / 255f, 111f / 255f);

	//Static fields for any default category
	public static readonly Category MentalHealth = new Category("Mental Health", MENTAL_BLUE_COLOR);
	public static readonly Category PhysicalHealth = new Category("Physical Health", PHYSICAL_RED_COLOR);
	public static readonly Category Leisure = new Category("Leisure", LEAISURE_GREEN_COLOR);
	public static readonly Category HouseKeeping = new Category("House Keeping", HOUSE_KEEPING_YELLOW_COLOR);

	public static readonly Category[] DefaultCategories = {
		MentalHealth,
		PhysicalHealth,
		Leisure,
		HouseKeeping
	};
	#endregion

	public string Name { get; set; }

	//TODO: Can be an int if necessary when serializing
	[JsonIgnore]
	public Color DisplayColor { get; set; }

	[JsonProperty("DisplayColor")]
	public int NumericColor => DisplayColor.GetRgbInteger();

	public Category(string name, Color displayColor)
	{
		this.Name = name;
		this.DisplayColor = displayColor;
	}


	public static bool operator ==(Category a, Category b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Category a, Category b)
	{
		return !a.Equals(b);
	}

	public override bool Equals(object obj)
	{
		return obj is Category category &&
			   Name == category.Name &&
			   DisplayColor.Equals(category.DisplayColor);
	}

	public override string ToString()
	{
		return this.Name;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Name, DisplayColor);
	}
}


