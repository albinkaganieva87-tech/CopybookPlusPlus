
public class Text
{
    public static string? text { get; set; }
    public static List<string> textfile = new List<string>();
}
public class Program
{
    public static string filename;
    
    public static void Main()
    {
        Console.WriteLine("<<<[COPYBOOK++] Текстовый Редактор>>>");
        bool b = true;
        while (b)
        {
            Action<string> del = (todel) =>
        {
            try
            {
                if (!File.Exists(todel)) { throw new FileNotFoundException("файл отсутствует"); }
                else File.Delete(todel);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"файл отсутсвует. {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка: файл занят или используется. {e.Message}");
            }
        };
            Action<string> op = (toop) =>
            {
                try
                {
                    if (!File.Exists(toop)) { throw new FileNotFoundException("файл отсутствует"); }
                    else
                    {
                        using (StreamReader reader = new StreamReader(toop))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }

                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine($"файл отсутсвует. {e.Message}");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Ошибка: файл занят или используется. {e.Message}");
                }
            };
            Console.Write("USR1> "); string com = Console.ReadLine();
            if (com.Contains("/cr"))
            {
                try
                {
                    Console.Write("имя создаваемого файла: "); filename = Console.ReadLine();
                    Creating.creatingtxt();
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine($"null не допустим в имени файла. {e.Message} ");
                }
            }
            else if (com.Contains("/del"))
            {
                try
                {
                    Console.Write("имя удаляемого файла: ");
                    filename = Console.ReadLine(); del(filename);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine($"null не допустим в имени файла. {e.Message} ");
                }

            }
            else if (com.Contains("/op"))
            {
                try
                {
                    Console.Write("имя открываемого файла: ");
                    filename = Console.ReadLine();
                    op(filename);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine($"null не допустим в имени файла. {e.Message} ");
                }
            }
            else if (com.Contains("/ex"))
            {
                break;
            }
            else if (com.Contains("/v"))
            {
                Console.WriteLine("abobix copybook++ 1.0");
            }
            else if (com.StartsWith("//") || com.StartsWith("#") || com.StartsWith("COM")) continue;
            else Console.WriteLine("unknown command");
        }
    }
}
public class Creating
{
    public static string fn = Program.filename; 
    delegate void Create();
    public static void creatingtxt()
    {
        Create saving = () => {
            using (StreamWriter writer = new StreamWriter(fn))
            {
                foreach (string g in Text.textfile)
                {
                    writer.WriteLine(g);
                }
            }
        };
        bool i = true;
        while(i)
        {
            int line = 1;
            Console.Write($"[FILE REDACT] || "); string text = Console.ReadLine();
            line++;
            if (text == "/com.save.ex") { saving(); Program.Main(); }
            else if (text == "/com.getpath") { Console.WriteLine(Path.GetFullPath(fn)); }
            else Text.textfile.Add(text);
            
        }
    }
}