namespace KinoStudia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Studio> studios = null;
            List<Director> directors = null;
            List<Film> films = null;

            Console.WriteLine("1 — InMemory, 2 — CSV");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InMemoryRepository memRepo = new InMemoryRepository();
                    studios = memRepo.GetStudios();
                    directors = memRepo.GetDirectors();
                    films = memRepo.GetFilms();
                    break;

                case "2":
                    CsvRepository csvRepo = new CsvRepository("C:\\data");
                    studios = csvRepo.GetStudios();
                    directors = csvRepo.GetDirectors();
                    films = csvRepo.GetFilms();
                    break;

                default:
                    Console.WriteLine("Неверный выбор");
                    return;
            }

            if (films == null || films.Count == 0)
            {
                Console.WriteLine("Данные не найдены.");
                return;
            }

            // 1. Поиск режиссёра фильма "Начало" (берём первый фильм из списка)
            Director dir = FindDirector(films[0], directors);
            Console.WriteLine("1. FindDirector(\"" + films[0].Title + "\"): " + (dir != null ? dir.GetInfo() : "—"));

            // 2. Поиск студии для этого же фильма
            Studio std = FindStudio(films[0], studios);
            Console.WriteLine("2. FindStudio(film \"" + films[0].Title + "\"): " + (std != null ? std.Info : "—"));

            // 3. Общий бюджет всех фильмов
            Console.WriteLine("3. GetTotalBudget: " + GetTotalBudget(films).ToString("0") + " руб.");

            // 4. Режиссёр с максимальным бюджетом (выводит сумму в скобках)
            string maxBudgetInfo = GetDirectorWithMaxBudget(films, directors);
            Console.WriteLine("4. GetDirectorWithMaxBudget: " + maxBudgetInfo);

            // 5. Вывод всех твоих 5 фильмов на экран
            Console.WriteLine("5. PrintAllFilms:");
            PrintAllFilms(films, directors, studios);

            // ДОБАВЛЯЕМ СТРОКУ "НЕ НАЙДЕНО" 
            Console.Write("\nНе найдено: FindDirector(\"Неизвестный фильм\") → ");
            Film fakeFilm = new Film { Title = "Неизвестный фильм", DirectorId = -99 };
            Director missingDir = FindDirector(fakeFilm, directors);
            if (missingDir == null)
                Console.WriteLine("null");
            else
                Console.WriteLine(missingDir.FullName);

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }

        static Director FindDirector(Film film, List<Director> directors)
        {
            if (film == null || directors == null) return null;
            foreach (var d in directors)
            {
                if (d.Id == film.DirectorId) return d;
            }
            return null;
        }

        static Studio FindStudio(Film film, List<Studio> studios)
        {
            if (film == null || studios == null) return null;
            foreach (var s in studios)
            {
                if (s.Id == film.StudioId) return s;
            }
            return null;
        }

        static decimal GetTotalBudget(List<Film> films)
        {
            if (films == null) return 0;
            decimal total = 0;
            foreach (var film in films)
            {
                total += film.Budget;
            }
            return total;
        }

        static string GetDirectorWithMaxBudget(List<Film> films, List<Director> directors)
        {
            if (films == null || directors == null || films.Count == 0 || directors.Count == 0) return "—";

            Dictionary<int, decimal> budgetMap = new Dictionary<int, decimal>();
            foreach (var f in films)
            {
                if (budgetMap.ContainsKey(f.DirectorId))
                    budgetMap[f.DirectorId] += f.Budget;
                else
                    budgetMap[f.DirectorId] = f.Budget;
            }

            int bestDirectorId = -1;
            decimal maxBudget = -1;

            foreach (var kvp in budgetMap)
            {
                if (kvp.Value > maxBudget)
                {
                    maxBudget = kvp.Value;
                    bestDirectorId = kvp.Key;
                }
            }

            foreach (var d in directors)
            {
                if (d.Id == bestDirectorId)
                {
                    return d.FullName + " (" + maxBudget.ToString("0") + ")";
                }
            }
            return "—";
        }

        static void PrintAllFilms(List<Film> films, List<Director> directors, List<Studio> studios)
        {
            if (films == null) return;
            foreach (var f in films)
            {
                // Выводим абсолютно все фильмы из списка!
                Director d = FindDirector(f, directors);
                Studio s = FindStudio(f, studios);

                string directorName = d != null ? d.FullName : "—";
                string studioName = s != null ? s.Name : "—";

                Console.WriteLine(f.GetInfo() + " — режиссёр " + directorName + ", студия \"" + studioName + "\"");
            }
        }
    }
}
