using System;
using System.Globalization;
using System.Text.Json;

namespace CultureTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var env = Environment.GetEnvironmentVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT");
			Console.WriteLine($"DOTNET_SYSTEM_GLOBALIZATION_INVARIANT={env}");

			try
			{
				var culture = new CultureInfo("fake-culture");
				Console.WriteLine(JsonSerializer.Serialize(new
				{
					culture.LCID,
					culture.DisplayName,
					culture.EnglishName,
					culture.NativeName
				}, new JsonSerializerOptions { MaxDepth = 32 }));
			}
			catch (Exception e)
			{
				Console.WriteLine($"Exception thrown\n\n{e.ToString()}");
			}

			Console.WriteLine("\n\nFinished");
		}
	}
}
