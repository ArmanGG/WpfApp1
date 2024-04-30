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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddComboBoxItems();


        }
        public void AddComboBoxItems()
        {
            ComboBox.Items.Add("+");
            ComboBox.Items.Add("-");
            ComboBox.Items.Add("*");
            ComboBox.Items.Add("/");

        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            frnum1.Text = String.Empty;
            frnum2.Text = String.Empty;
            frden2.Text = String.Empty;
            frden1.Text = String.Empty;
            frnum3.Text = String.Empty;
            frden3.Text = String.Empty;

        }
        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            int frn1 = int.Parse(frnum1.Text);
            int frn2 = int.Parse(frnum2.Text);
            int frd1 = int.Parse(frden1.Text);
            int frd2 = int.Parse(frden2.Text);
            int frn3 = 0;
            int frd3 = 1;
            var Combo1 = ComboBox.Text;
            var fr1 = new Fraction(frn1, frd1);
            var fr2 = new Fraction(frn2, frd2);
            switch (Combo1)
            {
                case "+":
                    ShowFr(fr1 + fr2);
                    break;
                case "-":
                    ShowFr(fr1 - fr2);
                    break;
                case "/":
                    ShowFr(fr1 / fr2);
                    break;
                case "*":
                    ShowFr(fr1 * fr2);
                    break;
                default:
                    break;
            }


        }
        private void ShowFr(Fraction fr)
        {
            SetDiv(ref fr);
            frnum3.Text = fr.Num.ToString();
            frden3.Text = fr.Den.ToString();
        }
        private int GetDiv(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        private void SetDiv(ref Fraction fr)
        {
            int div = GetDiv(fr.Num, fr.Den);
            fr = new Fraction(fr.Num / div, fr.Den / div);
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frden3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void frden1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
    public readonly struct Fraction
    {
        private readonly int num;
        private readonly int den;
        public int Num { get { return num; } }
        public int Den { get { return den; } }
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));

            }
            num = numerator; den = denominator;
        }
        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.num, a.den);
        public static Fraction operator +(Fraction a, Fraction b) => new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
        public static Fraction operator -(Fraction a, Fraction b) => a + (-b);
        public static Fraction operator /(Fraction a, Fraction b) => new Fraction(a.num * b.den, b.num * a.den);
        public static Fraction operator *(Fraction a, Fraction b) => new Fraction(a.num * b.num, a.den * b.den);

        public override string ToString() => $"{num}/{den}";
    }

}