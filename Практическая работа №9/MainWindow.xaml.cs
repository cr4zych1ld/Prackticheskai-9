using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Практическая_работа__9.MainWindow;

namespace Практическая_работа__9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод закрытия программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод выводящий информацию о задании для разработки программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoProga_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заполнить таблицу фильмотеки на 7 кассет с полями: \nфильм, жанр, год выпуска, продолжительность прос-\n" +
                "мотра. Вывести результат на экран. Вывести список \nфильмов заданного жанра.", "О программе: ", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Метод выводящий информацию о создателе программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoRazrab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Студент группы ИСП-31\nЖаров Артём Андреевич", "О создателе:", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Структура Movie предоставляющая информацию о фильме
        /// </summary>
        public struct Movie
        {
            public string Title;//Поле структуры с информацией о названии фильма
            public string Genre;//Поле структуры с информацией о жанре фильма
            public int Year;//Поле структуры с информацией о годе выхода фильма
            public int Duration;//Поле структуры с информацией о продолжительности фильма

            /// <summary>
            /// Конструктор структуры
            /// </summary>
            /// <param name="title">Название</param>
            /// <param name="genre">Жанр</param>
            /// <param name="year">Год</param>
            /// <param name="duration">Продолжительность</param>
            public Movie(string title, string genre, int year, int duration)
            {
                Title = title;
                Genre = genre;
                Year = year;
                Duration = duration;
            }
        }

        private List<Movie> movies;
        Movie movie;
        Movie mov;

        /// <summary>
        /// Метод автоматически заполняющий все необходимые данные о фильмах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMovies_Click(object sender, RoutedEventArgs e)
        {
            movies = new List<Movie>()
            {
                new("Красная шапочка", "Приключения", 2022, 96),
                new("Два капитана", "Приключения", 1976, 95),
                new("Джентельмены", "Криминал", 2019, 113),
                new("Один дома", "Комедия", 1990, 103),
                new("Аватар", "Фантастика", 2009, 162),
                new("Зверополис", "Мультфильм", 2016, 108),
                new("Зеленая миля", "Фэнтези", 1999, 189),
            };

            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i];
                OutputListBox.Items.Add($"{movie.Title}, {movie.Genre}, {movie.Year}, {movie.Duration}");
            }
        }

        /// <summary>
        /// Метод реализующий поиск фильма по указанному жанру(метод основан на очистке других полей с информацией о фильме, которые не удовлетворяют нужному жанру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMoviesByGenre_Click(object sender, RoutedEventArgs e)
        {
            mov = new Movie();
            mov.Genre = Convert.ToString(GenreTextBox.Text);

            for (int i = OutputListBox.Items.Count - 1; i >= 0; i--)
            {
                var movie = movies[i];
                if (mov.Genre != movie.Genre)
                {
                    OutputListBox.Items.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Создание вручную фильма с названием, с жанром, с годом и продолжительностью
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInfoFilmButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameFilm.Text != "" && NameGenreFilm.Text != "" && YearFilm.Text != null && TimeFilm.Text != null)
            {
                movie = new Movie();

                movie.Title = Convert.ToString(NameFilm.Text);
                movie.Genre = Convert.ToString(NameGenreFilm.Text);

                if (Int32.TryParse(YearFilm.Text, out int yearfilm) && Int32.TryParse(TimeFilm.Text, out int timefilm))
                {
                    movie.Year = Convert.ToInt32(yearfilm);
                    movie.Duration = Convert.ToInt32(timefilm);
                    OutputListBox.Items.Add($"{movie.Title}, {movie.Genre}, {movie.Year}, {movie.Duration}");
                }
                else MessageBox.Show("Введите целочисленные значения в нужные поля", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Введите всю информацию о фильме", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод удаляющий строку с введенным номер и появление ошибки если строки с таким номером не существует
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteStrokaButton_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(NumberStrock.Text, out int number))
            {
                if (number <= OutputListBox.Items.Count)
                {
                    OutputListBox.Items.RemoveAt(number - 1);
                }
                else MessageBox.Show("Строчки с таким номером не существует", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Введены некорректные значения", "Ошибка: ", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Метод для очистки выведенной информации о фильмах
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            OutputListBox.Items.Clear();
        }
    }
}