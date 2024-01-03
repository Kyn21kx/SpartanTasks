using Newtonsoft.Json;
using System.Threading.Tasks;

public static class JsonParser {

	private static readonly TaskFactory threadingFactory = new TaskFactory();
	//TODO: Add an exception callback here
	private static readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings {
		FloatParseHandling = FloatParseHandling.Decimal,
		NullValueHandling = NullValueHandling.Ignore,
		ReferenceLoopHandling = ReferenceLoopHandling.Error,
		Error = null
	};


	public static async Task<string> ToJsonAsync(object obj)
	{
		string result = await threadingFactory.StartNew(() => JsonConvert.SerializeObject(obj, serializerSettings));
		return result;
	}

	public static string ToJson(object obj)
	{
		string result = JsonConvert.SerializeObject(obj, serializerSettings);
		return result;
	}

	public static async Task<T> FromJsonAsync<T>(string json)
	{
		T result = await threadingFactory.StartNew(() => JsonConvert.DeserializeObject<T>(json, serializerSettings));
		return result;
	}

	public static T FromJson<T>(string json)
	{
		T result = JsonConvert.DeserializeObject<T>(json, serializerSettings);
		return result;
	}

}