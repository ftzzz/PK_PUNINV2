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

namespace ПР21101ПунинВариант2
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void CountVowelsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sentence = SentenceTextBox.Text.ToLower();
                if (sentence == "")
                    MessageBox.Show("Пустая строка");

                if (!IsEnglishSentence(sentence))
                {
                    MessageBox.Show("Введите предложение на английском языке!");
                    SentenceTextBox.Text = "";
                    return;
                }

                if (ContainsRussianLetters(sentence))
                {
                    MessageBox.Show("Введите предложение на английском языке!");
                    SentenceTextBox.Text = "";
                    return;
                }

                if (IsPunctuationOnly(sentence))
                {
                    MessageBox.Show("Введите предложение, содержащее буквы и/или слова!");
                    SentenceTextBox.Text = "";
                    return;
                }
                int vowelCount = CountVowels(sentence);
                string longestWord = GetLongestWord(sentence);

                VowelCountLabel.Content = $"Количество гласных: {vowelCount}";
                LongestWordLabel.Content = $"Самое длинное слово: {longestWord}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }
        private bool IsPunctuationOnly(string sentence)
        {
            foreach (char c in sentence)
            {
                if (Char.IsLetter(c) || c == ' ')
                {
                    return false;
                }
            }

            return true;
        }

        private bool ContainsRussianLetters(string sentence)
        {
            foreach (char c in sentence)
            {
                if ((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я'))
                {
                    return true;
                }
            }

            return false;
        }

        private int CountVowels(string sentence)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', };
            int count = 0;

            foreach (char c in sentence)
            {
                if (vowels.Contains(c))
                    count++;
            }

            return count;
        }

        private string GetLongestWord(string sentence)
        {
            string[] words = sentence.Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = string.Empty;

            foreach (string word in words)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }

            return longestWord;
        }

        private bool IsEnglishSentence(string sentence)
        {
            foreach (char c in sentence)
            {
                if (Char.IsLetter(c))
                {
                    if (!IsEnglishLetter(c))
                        return false;
                }
            }

            return true;
        }

        private bool IsEnglishLetter(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }
    }
}
