namespace KinoStudia;

/// <summary>
/// Представляет киностудию.
/// </summary>
public class Studio
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }

    /// <summary>
    /// Вычисляемое свойство: проверяет, является ли студия зарубежной.
    /// </summary>
    public bool IsForeign
    {
        get
        {
            return Country != "Россия";
        }
    }

    /// <summary>
    /// Свойство возвращает информацию о студии.
    /// </summary>
    public string Info
    {
        get
        {
            return Name + " (" + Country + ")";
        }
    }
}

