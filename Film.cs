namespace KinoStudia;

/// <summary>
/// Представляет кинофильм.
/// </summary>
public class Film
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int StudioId { get; set; } 
    public int DirectorId { get; set; } 
    public int Year { get; set; }
    public decimal Budget { get; set; }

    /// <summary>
    /// Вычисляемое свойство: проверяет, является ли бюджет большим.
    /// </summary>
    public bool IsExpensive
    {
        get
        {
            return Budget > 100000000m;
        }
    }

    /// <summary>
    /// Метод возвращает структурированную информацию о фильме.
    /// </summary>
    public string GetInfo()
    {
        return "\"" + Title + " (" + Year + ", " + Budget.ToString("0") + " руб.)\"";
    }


}
