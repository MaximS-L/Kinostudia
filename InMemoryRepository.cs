namespace KinoStudia
{
    /// <summary>
    /// Репозиторий для работы с тестовыми данными в оперативной памяти.
    /// </summary>
    public class InMemoryRepository
    {
        private List<Studio> _studios;
        private List<Director> _directors;
        private List<Film> _films;

        public InMemoryRepository()
        {
            _studios = new List<Studio>
            {
                new Studio { Id = 1, Name = "Warner Bros", Country = "США" },
                new Studio { Id = 2, Name = "Paramount", Country = "США" },
                new Studio { Id = 3, Name = "Мосфильм", Country = "Россия" },
                new Studio { Id = 4, Name = "Studio Ghibli", Country = "Япония" },
                new Studio { Id = 5, Name = "Ленфильм", Country = "Россия" }
            };

            _directors = new List<Director>
            {
                new Director { Id = 1, FullName = "К. Нолан", Experience = 20, Awards = 5 },
                new Director { Id = 2, FullName = "С. Спилберг", Experience = 45, Awards = 3 },
                new Director { Id = 3, FullName = "Л. Гайдай", Experience = 40, Awards = 2 },
                new Director { Id = 4, FullName = "Х. Миядзаки", Experience = 50, Awards = 1 },
                new Director { Id = 5, FullName = "К. Тарантино", Experience = 30, Awards = 4 }
            };

            _films = new List<Film>
            {
                new Film { Id = 1, Title = "Начало", StudioId = 1, DirectorId = 1, Year = 2010, Budget = 160000000m },
                new Film { Id = 2, Title = "Интерстеллар", StudioId = 2, DirectorId = 1, Year = 2014, Budget = 140000000m },
                new Film { Id = 3, Title = "Бриллиантовая рука", StudioId = 3, DirectorId = 3, Year = 1968, Budget = 5000000m },
                new Film { Id = 3, Title = "Тёмный рыцарь", StudioId = 1, DirectorId = 1, Year = 2008, Budget = 200000000m },
                new Film { Id = 5, Title = "Джанго освобождённый", StudioId = 2, DirectorId = 5, Year = 2012, Budget = 100000000m }
            };
        }

        public List<Studio> GetStudios() { return _studios; }
        public List<Director> GetDirectors() { return _directors; }
        public List<Film> GetFilms() { return _films; }
    }
}
