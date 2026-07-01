using System.Text.Json;

namespace Ziolek_Browser.Browser
{
    public class BookmarkManager
    {
        private readonly string file =
            Path.Combine(Application.StartupPath, "bookmarks.json");

        public List<string> Bookmarks { get; private set; } = new();

        public BookmarkManager()
        {
            Load();
        }

        public void Add(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return;

            if (!Bookmarks.Contains(url))
            {
                Bookmarks.Add(url);
                Save();
            }
        }

        public void Remove(string url)
        {
            if (Bookmarks.Remove(url))
                Save();
        }

        private void Save()
        {
            File.WriteAllText(file,
                JsonSerializer.Serialize(Bookmarks, new JsonSerializerOptions
                {
                    WriteIndented = true
                }));
        }

        private void Load()
        {
            if (!File.Exists(file))
                return;

            try
            {
                Bookmarks = JsonSerializer.Deserialize<List<string>>
                    (File.ReadAllText(file)) ?? new();
            }
            catch
            {
                Bookmarks = new();
            }
        }
    }
}