namespace KinoStudia;


/// <summary>
/// Репозиторий для считывания данных из CSV-файлов.
/// </summary>
public class CsvRepository
{
    private string _basePath;
    public CsvRepository(string basePath) { _basePath = basePath; }

    public List<Film> GetFilms()
    {
        List<Film> result = new List<Film>();
        string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(_basePath, "films.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',', ';');
            if (parts.Length < 6) continue;
            Film f = new Film();
            f.Id = int.Parse(parts[0]);
            f.Title = parts[1];
            f.StudioId = int.Parse(parts[2]);
            f.DirectorId = int.Parse(parts[3]);
            f.Year = int.Parse(parts[4]);
            f.Budget = decimal.Parse(parts[5]);
            result.Add(f);
        }
        return result;
    }

    public List<Studio> GetStudios()
    {
        List<Studio> result = new List<Studio>();
        string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(_basePath, "studios.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',', ';');
            if (parts.Length < 3) continue;
            Studio s = new Studio();
            s.Id = int.Parse(parts[0]);
            s.Name = parts[1];
            s.Country = parts[2];
            result.Add(s);
        }
        return result;
    }

    public List<Director> GetDirectors()
    {
        List<Director> result = new List<Director>();
        string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(_basePath, "directors.csv"));
        if (lines.Length < 2) return result;
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',', ';');
            if (parts.Length < 4) continue;
            Director d = new Director();
            d.Id = int.Parse(parts[0]);
            d.FullName = parts[1];
            d.Experience = int.Parse(parts[2]);
            d.Awards = int.Parse(parts[3]);
            result.Add(d);
        }
        return result;
    }
}
