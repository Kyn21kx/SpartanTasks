using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSelectionController {

	private const int NOON_HOUR = 12;

	public TimeSelectionController()
	{

	}

	public void AppendHourOptions(List<TMP_Dropdown.OptionData> options)
	{
		for (int i = 1; i <= NOON_HOUR; i++) {
			var currHour = new TMP_Dropdown.OptionData(ToTimeFormattedString(i));
			options.Add(currHour);
		}
	}

	public void AppendMinuteOptions(List<TMP_Dropdown.OptionData> options)
	{
		//Count to 59
		for (int i = 1; i <= 59; i++) {
			var currHour = new TMP_Dropdown.OptionData(ToTimeFormattedString(i));
			options.Add(currHour);
		}
	}

	public System.TimeSpan OptionToTimestamp(TMP_Dropdown.OptionData hourOption, TMP_Dropdown.OptionData minuteOption, bool pm)
	{
		bool wasHourParsed = int.TryParse(hourOption.text, out int resultHour);
		bool wasMinuteParsed = int.TryParse(minuteOption.text, out int resultMinute);
		if (!wasHourParsed || !wasMinuteParsed) {
			throw new UserFriendlyException("You must select a valid reminder time!");
		}
		resultHour = pm ? resultHour + NOON_HOUR : resultHour;
		return new System.TimeSpan(resultHour, resultMinute, 0);
	}


	private string ToTimeFormattedString(int timeValue)
	{
		if (timeValue < 10) return $"0{timeValue}";
		return timeValue.ToString();
	}

}
