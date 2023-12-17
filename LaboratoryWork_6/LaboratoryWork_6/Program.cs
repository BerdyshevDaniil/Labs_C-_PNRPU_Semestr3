using System.Text.RegularExpressions;

namespace Task_1
{
    internal class Program
    {
        static int InputInteger(string stringForUser = "")
        {
            int input;
            if (stringForUser != "") 
                Console.WriteLine(stringForUser);
            bool isInteger = Int32.TryParse(Console.ReadLine(), out input);
            while (!isInteger)
            {
                Console.WriteLine("Ошибка ввода! Попробуйте снова:");
                isInteger = Int32.TryParse(Console.ReadLine(), out input);
            }
            return input;
        }
        static void CheckNumber(int lowerBound, int upperBound, ref int value, string msgRepetitive = "Неверное значение! Попробуйте снова: ")
        {
            if (lowerBound > upperBound)
                (lowerBound, upperBound) = (upperBound, lowerBound);
            while (value < lowerBound || value > upperBound)
            {
                Console.WriteLine(msgRepetitive);
                value = InputInteger();
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine(
@"            Меню
0 - Завершение работы программы

        Задание 1:
1 - Создать рваный массив символов
2 - Вывести массив
3 - Удалить из массива последнюю строку, в которой есть не менее 3 символов цифр

        Задание 2:
4 - заполнить строку
5 - определить есть ли в строке ключевые слова C# и вывести, сколько раз встречается каждое слово");
        }
        static void Pause()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey(intercept: true);
        }
        // ФУНЦИЯ ЗАПОЛНЕНИЯ СТРОКИ 
        static void FillChars(ref char[] array)
        {
            Console.WriteLine("Введите строку:");
            array = Console.ReadLine().ToCharArray();
        }
        static void FillCharsRandom(ref char[] array)
        {
            int columns = InputInteger("Введите количество элементов строки:");
            CheckNumber(1, 50, ref columns);
            array = new char[columns];
            Random rand = new Random();
            for (int j = 0; j < array.Length; ++j)
                array[j] = Convert.ToChar(rand.Next(32, 127));
        }
        // ФУНЦИИ ДЛЯ РВАНОГО МАССИВА СИМВОЛОВ
        static void FillArray(ref char[][] array)
        {
            int rows = InputInteger("Введите количество строк:");
            array = new char[rows][];
            CheckNumber(1, 20, ref rows);
            for (int i = 0; i < rows; i++)
            {
                int fillingMethod = InputInteger($"Выберете способ заполнения строки:\n1 - случайными символами\n2 - вводом строки с клавиатуры");
                CheckNumber(1, 2, ref fillingMethod);
                if (fillingMethod == 1) 
                    FillCharsRandom(ref array[i]);
                if (fillingMethod == 2)
                    FillChars(ref array[i]);
                Console.WriteLine();
            }
        }
        static void PrintArray(char[][] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return;
            }
            Console.WriteLine("Рваный массив:");
            for (int i = 0; i < array.Length; ++i)
                Console.WriteLine(array[i]);
        }
        static void DeleteRow(ref char[][] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Массив пуст!");
                return;
            }
            Regex regex = new Regex(@".*\d.*\d.*\d.*");
            string[] stringArray = new string[array.GetLength(0)];
            for (int i = 0; i < stringArray.Length; ++i)
                stringArray[i] = new string(array[i]);

            int index = Array.FindLastIndex(stringArray, regex.IsMatch);

            if (index == -1)
                Console.WriteLine("Строк, удовлетворяющих условию не существует!");
            else
            {
                char[][] newArray = new char[array.Length - 1][];
                int j = 0;
                for (int i = 0; i < array.Length; ++i)
                {
                    if (i != index)
                    {
                        newArray[j] = array[i];
                        j++;
                    }
                }
                array = newArray;
                Console.WriteLine($"Строка {index + 1} удалена:\n{stringArray[index]}");
            }
        }
        /// <summary>
        /// Функция случайного заполнения строки
        /// </summary>
        /// <param name="line"> изменяемая строка</param>
        static void FillString(ref string line)
        {
            line = "";
            string[] firstWords = { "I", "We", "You", "They", "He", "She", "It" };
            string[] secondWords = { "abstract","as","base","bool","break","byte","case","catch","char","checked","class","const","continue","decimal","default",
                                    "delegate","do","double","else","enum","event","explicit","extern","false","finally","fixed","float","for","foreach","goto",
                                    "if","implicit","in","int","interface","internal","is","lock","long","namespace","new","null","object","operator","out","override",
                                    "params","private", "protected", "public","readonly","ref","return","sbyte","sealed","short", "sizeof","stackalloc","static",
                                    "string","struct","switch","this","throw","true","try","typeof","uint","ulong","unchecked","unsafe","ushort","using",
                                    "virtual","void","volatile","while","elbow","garbage","penetrate","raise","dependence","performance","coup","representative",
                                    "wolf","activate","steak","novel","impulse","leader","architect","pile","corner","import","absorb","cheese","match","conventional",
                                    "arrange","slime","exceed","extract","measure","domination","inject","empirical","officer","flood","economy","battlefield","dirty",
                                    "beginning","unaware","slap","dead","sentence","talk","utter","be","sunshine","formula","width","rate","pony", "decade",
                                    "pier","temptation","refund","war","moment","dose","offender","prestige","gutter","pig","reliance","modernize","consensus","indulge",
                                    "indication","season","nature","institution","elaborate","stem","provoke","defend","intermediate","format","Mars","deteriorate",
                                    "sand","bark","vessel","cousin","roar","final","lift","grind","steam","forge","seek","section","give","power","wife","sock","enter",
                                    "bury","motorcycle","finished","domestic","subject","contact","bathtub"};
            string[] punctuation = { ".", ",", "!", "?", ":", ";" };
            Random rand = new Random();
            int suggestionCount = rand.Next(2, 4);
            for (int i = 0; i <= suggestionCount; ++i)
            {
                line = line + firstWords[rand.Next(0, firstWords.Length)] + ' ';
                int wordsCount = rand.Next(4, 6);
                for (int j = 0; j <= wordsCount; ++j)
                {
                    line += secondWords[rand.Next(0, secondWords.Length)];
                    if (j != wordsCount)
                        line += ' ';
                }
                line = line + punctuation[rand.Next(0, punctuation.Length)] + ' ';
            }
        }
        /// <summary>
        /// Функция заполнения строки демонстрационными предложениями
        /// </summary>
        /// <param name="line"></param>
        static void ChooseString(ref string line)
        {
            line = "";
            string[] demonstrationSuggestions = { "\"in?     int,....interface;internal:isis,lock,.longю,!namespace ,ne",
                                                        "if,,,if...if!!!ifif if",
                                                        "I'm sorry, but \"namespace\" and \"new\" are not included in the given list of words. Please provide a new list of words for me to use in a sentence."};
            Console.WriteLine("Выберите демонстрационное предложение:");
            for (int i = 0; i < demonstrationSuggestions.Length; ++i)
            {
                Console.WriteLine($"{i + 1}) {demonstrationSuggestions[i]}");
            }
            var suggestionNumber = InputInteger();
            CheckNumber(1, demonstrationSuggestions.Length, ref suggestionNumber);
            line = demonstrationSuggestions[suggestionNumber - 1];
            Console.WriteLine(line);
        }

        /// <summary>
        /// ФУНКЦИЯ ПОИСКА КЛЮЧЕВЫХ СЛОВ В СТРОКЕ
        /// </summary>
        /// <param name="line"></param>
        static void SearchKeyWords(string line)
        {
            if (line.Length == 0)
            {
                Console.WriteLine("Строка пустая!");
                return;
            }
            string[] keyWords = { "abstract","as","base","bool","break","byte","case","catch","char","checked","class","const","continue","decimal","default",
                                    "delegate","do","double","else","enum","event","explicit","extern","false","finally","fixed","float","for","foreach","goto",
                                    "if","implicit","in","int","interface","internal","is","lock","long","namespace","new","null","object","operator","out","override",
                                    "params","private", "protected", "public","readonly","ref","return","sbyte","sealed","short", "sizeof","stackalloc","static",
                                    "string","struct","switch","this","throw","true","try","typeof","uint","ulong","unchecked","unsafe","ushort","using",
                                    "virtual","void","volatile","while"};
            int[] keyWordsNumber = new int[keyWords.Length];
            string[] lineWords = line.Split(' ', '!', '.', '?', ',', ';', ':');
            for (int i = 0; i < keyWords.Length;++i)
            {
                foreach (string j in lineWords) 
                {
                    if (keyWords[i] == j)
                        ++keyWordsNumber[i];
                }
            }
            if (keyWordsNumber.Max() > 0)
            {
                Console.WriteLine("\nВ предложении встретились следующие ключевые слова:");
                for (int i = 0; i<keyWords.Length; ++i)
                {
                    if (keyWordsNumber[i] != 0)
                        Console.WriteLine($"{keyWords[i]}: встретилось {keyWordsNumber[i]} раз");
                }
            }
            else
                Console.WriteLine("В предложении не найдено ключевых слов!");
        }
        static void Menu()
        {
            int switchN;
            char[][] unevenArray = { };
            string line = "";
            do
            {
                Console.Clear();
                ShowMenu();
                switchN = InputInteger();
                switch (switchN)
                {
                    case 0:
                        Console.WriteLine("Работа завершена!");
                        break;
                    case 1:
                        FillArray(ref unevenArray);
                        Pause();
                        break;
                    case 2:
                        PrintArray(unevenArray);
                        Pause();
                        break;
                    case 3:
                        DeleteRow(ref unevenArray);
                        Pause();
                        break;
                    case 4:
                        Console.Clear();
                        int switchOperation = InputInteger("1 - ввести строку с клавиатуры\n2 - заполнить строку случайными словами\n3 - загрузить демонстрационные предложения");
                        CheckNumber(1, 3, ref switchOperation);
                        if (switchOperation == 1)
                        {
                            Console.WriteLine("Введите строку:");
                            line = Console.ReadLine();
                        }
                        if (switchOperation == 2)
                        {
                            FillString(ref line);
                            Console.WriteLine(line);
                        }
                        if (switchOperation == 3)
                        {
                            ChooseString(ref line);
                        }
                        Pause();
                        break;
                    case 5:
                        Console.WriteLine(line);
                        SearchKeyWords(line);
                        Pause();
                        break;
                    default:
                        Console.WriteLine("Неправильно введено значение!");
                        Pause();
                        break;
                }
            } while (switchN != 0);
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}