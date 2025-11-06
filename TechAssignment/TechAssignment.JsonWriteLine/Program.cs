using System.Reflection;
using System.Text;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        var file = "res\\testData.json";
        var basePath= Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        string path = Path.Combine(basePath, file);
        
        var consoleJson = new JsonConsoleWriteLine();
        var jsontxt = consoleJson.Read(path);
        consoleJson.ConsoleRaw(jsontxt);
    }
}

public class JsonConsoleWriteLine
{
    public string Read(string path)
    {
        var original = File.ReadAllText(path);

        //Formatting string regardless of its original formatting
        using JsonDocument doc = JsonDocument.Parse(original);        
        return JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions
        {
            WriteIndented = false
        });
    }

    void AppendSpace(StringBuilder stringBuilder, int nest)
    {
        for (int i = 0; i < nest; i++)
        {
            stringBuilder.Append(' ');
            stringBuilder.Append(' ');
        }
    }

    public void ConsoleRaw(string raw)
    {
        int nest = 0;

        var formattedRaw = new StringBuilder();
        var rawArr = raw.ToCharArray();

        foreach (var s in rawArr)
        {
            switch (s)
            {
                case '"':
                    formattedRaw.Append(s);
                    break;
                case '{':
                case '[':
                    formattedRaw.Append(s).Append('\n');
                    AppendSpace(formattedRaw, ++nest);
                    break;                
                case ']':
                case '}':                    
                    formattedRaw.Append('\n');
                    AppendSpace(formattedRaw, --nest);
                    formattedRaw.Append(s);
                    break;
                case ':':
                    formattedRaw.Append(s);
                    formattedRaw.Append(' ');
                    break;
                case ',':
                    formattedRaw.Append(s).Append('\n');
                    AppendSpace(formattedRaw, nest);
                    break;
                default:
                    formattedRaw.Append(s);
                    break;

            }
        }

        var result = formattedRaw.ToString();
        Console.WriteLine(result);
    }
}