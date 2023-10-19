using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window  
    {

        private int[,] matrix;
        private int M, N;

        public MainWindow()
        {
            InitializeComponent();
            Height += 20;
            
        }

        private void MText_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана матрица размера M × N и целое число K (1 ≤ K ≤ M). Найти сумму и\r\nпроизведение элементов K-й строки данной матрицы. Кудинов ИСП-34" );
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MText.Clear();
            NText.Clear();
            KText.Clear();
            MatrixTextBox.Clear();
            suma.Clear();
            proiz.Clear();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(MText.Text, out M) || M <= 0)
            {
                MessageBox.Show("Некорректное значение M");
                return;
            }

            if (!int.TryParse(NText.Text, out N) || N <= 0)
            {
                MessageBox.Show("Некорректное значение N");
                return;
            }

            if (!int.TryParse(KText.Text, out int K) || K  <= 1 || K > M)
            {
                MessageBox.Show("Некорректное значение K");
                return;
            }

            matrix = new int[M, N];

            // Заполнение матрицы случайными числами от 1 до 10
            Random random = new Random();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = random.Next(1, 11);
                }
            }

            // Вывод матрицы в текстовое поле
            MatrixTextBox.Text = "";
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MatrixTextBox.Text += matrix[i, j] + " ";
                }
                MatrixTextBox.Text += Environment.NewLine;
            }

            int sum = 0;
            int comp = 1;

            // Вычисление суммы и произведения элементов K-й строки
            for (int j = 0; j < N; j++)
            {
                sum += matrix[K - 1, j];
                comp *= matrix[K - 1, j];
            }

            suma.Text = sum.ToString();
            proiz.Text = comp.ToString();
        }
    }
}

