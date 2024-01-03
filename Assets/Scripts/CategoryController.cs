

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;

public class CategoryController {

	private const int MAX_CATEGORIES = 40;
	private Category[] allCategories;

	public CategoryController()
	{
		this.allCategories = new Category[MAX_CATEGORIES];
	}

	public void AppendCategoryOptions(List<TMP_Dropdown.OptionData> listReference)
	{
		//Get the default ones, and any set by the user
		Category[] defaultCategories = Category.DefaultCategories;
		//Fetch the data from the user's PlayerPrefs
		//Append that to the DefaultCategoriesArray
		
		for (int i = 0; i < defaultCategories.Length; i++)
		{
			if (this.allCategories[i] == default)
			{
				//The category is empty, so, we should assign it
				this.allCategories[i] = defaultCategories[i];
			}
			TMP_Dropdown.OptionData currOption = new TMP_Dropdown.OptionData(defaultCategories[i].Name);
			listReference.Add(currOption);
		}
	}

	public Category FindCategoryByName(string name)
	{
		//Linear search is much faster with small elements (i.e 40), so, yeah
		for (int i = 0; i < this.allCategories.Length; i++)
		{
			Category currCategory = this.allCategories[i];
			if (currCategory == default) break; //We've reached the end of the array
			if (currCategory.Name == name) return currCategory;
		}
		throw new Exception("Category not found, please verify its name");
	}
}
