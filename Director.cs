namespace KinoStudia;

/// <summary>
/// Представляет режиссёра фильма.
/// </summary>
public class Director
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public int Experience { get; set; }
    public int Awards { get; set; }

    /// <summary>
    /// Вычисляемое свойство: проверяет опыт режиссёра (более 10 лет).
    /// </summary>
    public bool IsExperienced
    {
        get
        {
            return Experience > 10;
        }
    }

    /// <summary>
    /// Метод возвращает полную информацию о режиссёре.
    /// </summary>
    public string GetInfo()
    {
        return FullName + " (" + Experience + " лет, " + Awards + " наград)";
    }
}
