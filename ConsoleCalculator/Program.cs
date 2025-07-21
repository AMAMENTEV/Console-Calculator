
namespace ConsoleCalculator
{
    class Program
    {
        static void Main()
        {
            
            /// счетчик кол-ва ошибок в программе
            int count = 0;
            string input = "";
            List<string> array_with_elements = new List<string>();


            /// ввод строки
            input = Console.ReadLine();
               
                input = input.Replace(")(", ") * (").Replace(")", " ) ").Replace("(", " ( ").Replace(".", ",").Replace("  ", " ").Replace("0 (", "0 * (").Replace("1 (", "1 * (").Replace("2 (", "2 * (").Replace("3 (", "3 * (").Replace("4 (", "4 * (").Replace("5 (", "5 * (").Replace("6 (", "6 * (").Replace("7 (", "7 * (").Replace("8 (", "8 * (").Replace("9 (", "9 * (").Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ").Replace("  ", " ").Replace("  ", " ");

                if (input[0] == ' ')
                {
                    input = input.Substring(1);
                }


                /// создание списка с элементами строки (элемнтами считаются операторы, числа и скобки)    
                array_with_elements = new List<string>(input.Split(' '));


                /// проверим программу на ошибки
                /// количество ( должно быть равно )
                /// скобки не должны быть пустыми
                /// после ( и до ) не должен идти оператор
                /// в строке не должны содержаться ненужные символы
                /// первой скобкой не может быть ), а последней (
                /// не должно быть деления на 0
                /// оператор не первый и не последний элемент списка


                try
                {
                    Console.WriteLine(Evaluate());  /// вызов метода, который переведет наш list в результат
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    count += 1;
                }

                if (count > 0) { if (count >= 3) { Console.WriteLine("You have broken the code"); } }
            


                /// определение метода подсчёта результата
                double Evaluate()
                {



                    List<string> count_open = new List<string>();
                    List<string> count_close = new List<string>();
                    List<string> simbols = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", "(", ")", "+", "-", "*", "/", "," };

                    
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (simbols.Contains(input[i].ToString()) != true) { throw new WrongSymbols("строка содержит лишние символы"); } /// проверка на лишние символы
                        }
                   
                   
                        for (int i = 0; i < array_with_elements.Count - 1; i++)
                        {
                            if ((array_with_elements[i] == "+" || array_with_elements[i] == "-" || array_with_elements[i] == "*" || array_with_elements[i] == "/") && (array_with_elements[i + 1] == "+" || array_with_elements[i + 1] == "-" || array_with_elements[i + 1] == "*" || array_with_elements[i + 1] == "/")) 
                            { 
                                throw new WrongSymbols("два оператора подряд"); 
                            }
                        }
                    
                    
                        for (int i = 0; i < array_with_elements.Count; i++)
                        {
                            if (array_with_elements[i] == "(") { count_open.Add(i.ToString()); }
                            if (array_with_elements[i] == ")") { count_close.Add(i.ToString()); }
                        }
                   
                    
                        if (count_open.Count != count_close.Count) { throw new ErrorSkobka("скобки не уравновешены"); } /// проверка на равенство кол-ва скобок
                    
                    
                        if (count_open.Count != 0 && count_close.Count != 0)
                        {
                            if (Convert.ToInt32(count_open[0]) > Convert.ToInt32(count_close[0])) { count += 1; throw new ErrorSkobka("перед ) должна быть ("); } /// проверка что первая скобка не )
                            if (Convert.ToInt32(count_open[count_open.Count - 1]) > Convert.ToInt32(count_close[count_close.Count - 1])) { count += 1; throw new ErrorSkobka("после ( должна быть )"); }/// проверка что первая скобка не (
                        }
                    
                    
                        for (int i = 0; i < array_with_elements.Count - 1; i++)
                        {
                            if (array_with_elements.Contains("()") == true) { throw new ErrorSkobka("скобки пусты"); } /// проверка на пустные скобки 
                        }
                   
                    /// проверка на то что первый и последний элемент не операторы
                    
                        if ((array_with_elements[0] == "+") || (array_with_elements[0] == "-") || (array_with_elements[0] == "*") || (array_with_elements[0] == "/")) 
                        {
                            throw new Operator("оператор не может быть в начале"); 
                        }
                    
                    
                        if ((array_with_elements[array_with_elements.Count - 1] == "+") || (array_with_elements[array_with_elements.Count - 1] == "-") || (array_with_elements[array_with_elements.Count - 1] == "*") || (array_with_elements[array_with_elements.Count - 1] == "/")) { count += 1; throw new Operator("оператор не может быть в конце"); }
                    
                        for (int i = 0; i < array_with_elements.Count - 1; i++)
                        {
                            /// проверим, что после открытой скобками нет +-*/
                            if (array_with_elements[i] == "(" && (array_with_elements[i + 1] == "+" || array_with_elements[i + 1] == "-" || array_with_elements[i + 1] == "*" || array_with_elements[i + 1] == "/")) 
                            { 
                                throw new Poriadok("нарушен порядок скобок и операторов"); 
                            }

                            /// проверим, что перед закрытой скобками нет +-*/
                            if (array_with_elements[i + 1] == ")" && (array_with_elements[i] == "+" || array_with_elements[i] == "-" || array_with_elements[i] == "*" || array_with_elements[i] == "/")) { count += 1; throw new Poriadok("нарушен порядок скобок и операторов"); }
                        }


                    for (int i = 0; i < array_with_elements.Count - 1; i++)
                    {
                        if (array_with_elements[i] == "/" && array_with_elements[i + 1] == "0")
                        {
                            throw new ZeroDelenie("деление на 0");
                        } /// проверка деления на 0
                    }
                     
                    
                    

                    /////////
                    /// вспомогательный список, помогающий преобразовать array_with_elements и array in skobka в список, в котором останутся только + и -
                    List<string> help_array = new List<string>();




                    /// позиция "(" после которой пойдет ")" и позиция этой ")"
                    int open_position = -1;
                    int closed_position = 0;



                    /// избавимся от скобок, заменив их на результат внутреннего выражения 
                    while ((array_with_elements.Contains("(") == true) || (array_with_elements.Contains(")") == true))
                    {

                        for (int i = 0; i < array_with_elements.Count; i++)
                        {
                            if (array_with_elements[i] == "(") /// ищем индекс "(", после которой пойдет ")"
                            {
                                open_position = i;
                            }
                            if (array_with_elements[i] == ")")
                            {
                                closed_position = i;
                                if (open_position == -1)
                                { throw new ErrorSkobka(""); }
                                else
                                {
                                    List<string> array_in_skboka = new List<string>(); /// создаем список, в котором будет выражение внутрискобочное выражение
                                    for (int j = open_position + 1; j < closed_position; j++)
                                    {
                                        array_in_skboka.Add(array_with_elements[j]);
                                    }

                                    /// преобразуем это выражение в результирующее число

                                    while ((array_in_skboka.Contains("*") == true) || (array_in_skboka.Contains("/") == true))
                                    {

                                        for (int k = 0; k < array_in_skboka.Count; k++)
                                        {
                                            switch (array_in_skboka[k])
                                            {
                                                case "*":
                                                    /// добавление в вспомогательный массив всех элементов до умножения
                                                    for (int j = 0; j < k - 1; j++)
                                                    {
                                                        help_array.Add(array_in_skboka[j]);
                                                    }

                                                    /// добавление в вспомогательный массив элемент, равный произведению
                                                    help_array.Add((Convert.ToDouble(array_in_skboka[k - 1]) * Convert.ToDouble(array_in_skboka[k + 1])).ToString());

                                                    /// добавление всего, что идет после умножения
                                                    for (int j = k + 2; j < array_in_skboka.Count; j++)
                                                    {
                                                        help_array.Add(array_in_skboka[j]);
                                                    }

                                                    array_in_skboka.Clear();
                                                    for (int j = 0; j < help_array.Count; j++)
                                                    {
                                                        array_in_skboka.Add(help_array[j]);
                                                    }
                                                    help_array.Clear();
                                                    break;

                                                case "/":
                                                    /// добавление в вспомогательный массив всех элементов до деления
                                                    for (int j = 0; j < k - 1; j++)
                                                    {
                                                        help_array.Add(array_in_skboka[j]);
                                                    }

                                                    /// добавление в вспомогательный массив элемент, равный произведению
                                                    help_array.Add((Convert.ToDouble(array_in_skboka[k - 1]) / Convert.ToDouble(array_in_skboka[k + 1])).ToString());

                                                    /// добавление всего, что идет после умножения
                                                    for (int j = k + 2; j < array_in_skboka.Count; j++)
                                                    {
                                                        help_array.Add(array_in_skboka[j]);
                                                    }

                                                    array_in_skboka.Clear();
                                                    for (int j = 0; j < help_array.Count; j++)
                                                    {
                                                        array_in_skboka.Add(help_array[j]);
                                                    }
                                                    help_array.Clear();
                                                    break;




                                            }



                                        }

                                    }

                                    double chislo = Convert.ToDouble(array_in_skboka[0]);
                                    /// вычисление значения списка внутри скобки
                                    for (int j = 1; j < array_in_skboka.Count; j++)
                                    {
                                        switch (array_in_skboka[j])
                                        {
                                            case "+":
                                                chislo += Convert.ToDouble(array_in_skboka[j + 1]); break;
                                            case "-":
                                                chislo -= Convert.ToDouble(array_in_skboka[j + 1]); break;
                                        }
                                    }


                                    /// перезапись строки с скобками без замененной скобки

                                    for (int j = 0; j < open_position; j++)
                                    {
                                        help_array.Add(array_with_elements[j]);
                                    }

                                    help_array.Add(chislo.ToString());

                                    for (int j = closed_position + 1; j < array_with_elements.Count; j++)
                                    {
                                        help_array.Add(array_with_elements[j]);
                                    }

                                    array_with_elements.Clear();
                                    for (int j = 0; j < help_array.Count; j++)
                                    {
                                        array_with_elements.Add(help_array[j]);
                                    }
                                    help_array.Clear();
                                    array_in_skboka.Clear();
                                    break;
                                }

                            }
                        }
                    }


                    ///сначала разбираемся с умножением и делением (заменям пары чисел на одно результирующее число)
                    while ((array_with_elements.Contains("*") == true) || (array_with_elements.Contains("/") == true))
                    {

                        for (int i = 0; i < array_with_elements.Count; i++)
                        {
                            switch (array_with_elements[i])
                            {
                                case "*":
                                    /// добавление в вспомогательный массив всех элементов до умножения
                                    for (int j = 0; j < i - 1; j++)
                                    {
                                        help_array.Add(array_with_elements[j]);
                                    }

                                    /// добавление в вспомогательный массив элемент, равный произведению
                                    help_array.Add((Convert.ToDouble(array_with_elements[i - 1]) * Convert.ToDouble(array_with_elements[i + 1])).ToString());

                                    /// добавление всего, что идет после умножения
                                    for (int j = i + 2; j < array_with_elements.Count; j++)
                                    {
                                        help_array.Add(array_with_elements[j]);
                                    }

                                    array_with_elements.Clear();
                                    for (int j = 0; j < help_array.Count; j++)
                                    {
                                        array_with_elements.Add(help_array[j]);

                                    }
                                    help_array.Clear();

                                    break;

                                case "/":
                                    /// добавление в вспомогательный массив всех элементов до деления
                                    for (int j = 0; j < i - 1; j++)
                                    {
                                        help_array.Add(array_with_elements[j]);
                                    }

                                    /// добавление в вспомогательный массив элемент, равный частному
                                    help_array.Add((Convert.ToDouble(array_with_elements[i - 1]) / Convert.ToDouble(array_with_elements[i + 1])).ToString());

                                    /// добавление всего, что идет после деления
                                    for (int j = i + 2; j < array_with_elements.Count; j++)
                                    {
                                        help_array.Add(array_with_elements[j]);
                                    }

                                    array_with_elements.Clear();
                                    for (int j = 0; j < help_array.Count; j++)
                                    {
                                        array_with_elements.Add(help_array[j]);

                                    }
                                    help_array.Clear();

                                    break;
                            }
                        }

                    }

                    /// теперь у нас получился список, содержащий только числа и операнты + и -

                    double result = Convert.ToDouble(array_with_elements[0]);

                    /// вычисление значения списка
                    for (int i = 1; i < array_with_elements.Count; i++)
                    {
                        switch (array_with_elements[i])
                        {
                            case "+":
                                result += Convert.ToDouble(array_with_elements[i + 1]); break;
                            case "-":
                                result -= Convert.ToDouble(array_with_elements[i + 1]); break;
                        }
                    }





                    return result;


                }
                

            }

        }
    }

