#include <iostream>
#include <Windows.h>
#include <string>
#include <stack>
#include <sstream>
#include "Set.h"
using namespace std;

int choose_set(string msg = "Выберете множество:\n1 - A, 2 - B, 3 - C.\n")
{
    cout << msg;
    int set_number = input_integer();
    while (set_number != 1 && set_number != 2 && set_number != 3)
    {
        cout << "Некоректный ввод! Попробуйте снова: ";
        set_number = input_integer();
    }
    return set_number;
}

void choose_operation(int operation, Set A1, Set A2, Set& A3)
{
    if (operation == 1)
        A3.Intersection(A1, A2);
    else if (operation == 2)
        A3.Union(A1, A2);
    else if (operation == 3)
        A3.Subtraction(A1, A2);
    else if (operation == 4)
        A3.SymmetrySubstraction(A1, A2);
}

void print_info(Set& A, Set& B, Set& C)
{
    cout << "Универсум: ";
    cout << endl;
    Set::get_lower_bound();
    Set::get_upper_bound();
    cout << "Множество A: ";
    A.print();
    cout << "Множество B: ";
    B.print();
    cout << "Множество С: ";
    C.print();
}

struct Leksema //Структура, описывающая любое множество или операцию
{
    char type; // 0 для множеств, "^" для операции пересечения и т.д.
    Set value; // только для множеств
};

bool Operations(stack <Leksema>& Stack_s, stack <Leksema>& Stack_o, Leksema& item)
{ // Функция, которая производит расчеты
// Функция имеет тип bool, чтобы при возникновении какой-либо ошибки возвращать "false"
    Set a, b, c;
    a = Stack_s.top().value; // Берется верхнее множество из стека с множествами
    Stack_s.pop(); // Удаляется верхнее множество из стека
    switch (Stack_o.top().type)
    {  // Проверяется тип верхней операции из стека с операциями

    case '^': // Если тип верхней операции из стека с операциями сложение
        b = Stack_s.top().value;
        Stack_s.pop();
        c.Intersection(a, b);
        item.type = '0';
        item.value = c;
        Stack_s.push(item); //Результат операции кладется обратно в стек
        Stack_o.pop();
        break;

    case 'U':
        b = Stack_s.top().value;
        Stack_s.pop();
        c.Union(b, a);
        item.type = '0';
        item.value = c;
        Stack_s.push(item);
        Stack_o.pop();
        break;

    case '\\':
        b = Stack_s.top().value;
        Stack_s.pop();
        c.Subtraction(b, a);
        item.type = '0';
        item.value = c;
        Stack_s.push(item);
        Stack_o.pop();
        break;

    case 'X':
        b = Stack_s.top().value;
        Stack_s.pop();
        c.SymmetrySubstraction(a, b);
        item.type = '0';
        item.value = c;
        Stack_s.push(item);
        Stack_o.pop();
        break;

    case '~':
        c.Сomplement(a);
        item.type = '0';
        item.value = c;
        Stack_s.push(item);
        Stack_o.pop();
        break;

    default:
        cerr << "\nОшибка!\n";
        return false;
        break;
    }
    return true;
}

int getRang(char Ch)
{ //Функция возвращает приоритет операции: "1" для сложения и вычитания, "2" для умножения и деления и т.д.
    if (Ch == '~') return 4;
    if (Ch == '^') return 3;
    if (Ch == 'U') return 2;
    if (Ch == '\\' || Ch == 'X') return 1;
    else return 0;
}

void handle_string(Set& A, Set& B, Set& C)
{
    system("cls");

    cout << "Введите выражение:\nДоступные множества: A, B, C.\n";
    print_info(A, B, C);
    cout << "Операции:\nU - объединение;\n^ -пересечение;\n~ - дополнение;\n\\ - разность;\nX - симметрическая разность.\n";

    string expression;
    getline(cin, expression); getline(cin, expression);
    stringstream sstr{ expression };

    char Ch; //Переменная, в которую будет записываться текущий обрабатываемый символ
    Set D;
    stack<Leksema> Stack_s; //Стек с множествами
    stack<Leksema> Stack_o; //Стек с операциями
    Leksema item; //Объект типа Leksema
    while (true)
    {
        Ch = sstr.peek(); //Смотрим на первый символ
        if (Ch == '\377')break; //Если достигнут конец строки, выходим из цикла
        if (Ch == ' ')
        { //Игнорирование пробелов
            sstr.ignore();
            continue;
        }
        if (Ch == 'A' || Ch == 'B' || Ch == 'C' || Ch == 'a' || Ch == 'b' || Ch == 'c')
        { //Если прочитано множество
            if (Ch == 'A' || Ch == 'a')
            {
                D = A;
                item.type = '0';
                item.value = D;
                Stack_s.push(item); // Множество кладется в стек
                sstr.ignore();
                continue;
            }
            if (Ch == 'B' || Ch == 'b')
            {
                D = B;
                item.type = '0';
                item.value = D;
                Stack_s.push(item); // Множество кладется в стек
                sstr.ignore();
                continue;
            }
            if (Ch == 'C' || Ch == 'c')
            {
                D = C;
                item.type = '0';
                item.value = D;
                Stack_s.push(item); // Множество кладется в стек
                sstr.ignore();
                continue;
            }
        }
        if (Ch == '^' || Ch == '~' || Ch == 'U' || Ch == '\\' || Ch == 'X')
        { //Если прочитана операция
            if (Stack_o.size() == 0)
            { //Если стек с операциями пуст
                item.type = Ch;
                Stack_o.push(item); //Операция кладется в стек с операциями
                sstr.ignore();
                continue;
            }
            if (Stack_o.size() != 0 && getRang(Ch) >
                getRang(Stack_o.top().type))
            { //Если стек с операциями НЕ пуст, но приоритет текущей операции выше верхней в стеке с операциями
                item.type = Ch;
                Stack_o.push(item); //Операция кладется в стек с операциями
                sstr.ignore();
                continue;
            }
            if (Stack_o.size() != 0 && getRang(Ch) <=
                getRang(Stack_o.top().type))
            {//Если стек с операциями НЕ пуст, но приоритет текущей операции ниже либо равен верхней в стеке с операциями
                if (Operations(Stack_s, Stack_o, item) == false)
                { //Если функция вернет "false", то прекращаем работу
                    return;
                }
                continue;
            }
        }
        if (Ch == '(')
        { //Если прочитана открывающаяся скобка
            item.type = Ch;
            Stack_o.push(item); //Операция кладется в стек с операциями
            sstr.ignore();
            continue;
        }
        if (Ch == ')')
        { //Если прочитана закрывающаяся скобка
            while (Stack_o.top().type != '(')
            {
                if (Operations(Stack_s, Stack_o, item) == false)
                { //Если функция вернет "false", то прекращаем работу
                    return;
                }
                if (Stack_o.empty())
                {
                    cout << "\nНеверно введено выражение!\n";
                    return;
                }
                else
                    continue;
            }
            Stack_o.pop();
            sstr.ignore();
            continue;
        }
        else
        { //Если прочитан неизвестный символ
            cout << "\nНеверно введено выражение!\n";
            return;
        }
    }
    while (Stack_o.size() != 0)
    { // Вызываем операционную функцию до тех пор, пока в стеке с операциями не будет 0 элементов
        if (Operations(Stack_s, Stack_o, item) == false)
        { // Если функция вернет "false", то прекращаем работу
            return;
        }
        else continue; // Если все хорошо
    }
    cout << "   Ответ: ";
    Stack_s.top().value.print(); //Выводим ответ
}

void show_menu()
{
    cout << "\t\tМеню\n";
    cout << "0 - завершение работы программы\n";
    cout << "1 - заполнить множество\n";
    cout << "2 - вывести данные о множествах\n";
    cout << "3 - выполнить базовые операции над множествами\n";
    cout << "4 - ввести выражение\n";
}

void menu()
{
    int switch_n, set_number, set_number2, operation;
    Set A, B, C, D;
    do
    {
        system("pause");
        system("cls");
        show_menu();
        switch_n = input_integer();
        switch (switch_n)
        {
        case 0:
            cout << "Работа завершена!";
            break;
        case 1:
            set_number = choose_set();
            if (set_number == 1)
                A.fill_set();
            else if (set_number == 2)
                B.fill_set();
            else if (set_number == 3)
                C.fill_set();
            break;
        case 2:
            print_info(A, B, C);
            break;
        case 3:
            set_number = choose_set();
            cout << "Выберите операцию:\n1 - Пересечение, 2 - Объединение, 3 - Разность, 4 - Симметрическая разность, 5 - Дополнение.\n";
            operation = input_integer();
            check_number(1, 5, operation);
            if (operation != 5)
            {
                set_number2 = choose_set("Выберете множество 2:\n1 - A, 2 - B, 3 - C.\n");
                switch (set_number)
                {
                case 1:
                    switch (set_number2)
                    {
                    case 1:
                        choose_operation(operation, A, A, D);
                        break;
                    case 2:
                        choose_operation(operation, A, B, D);
                        break;
                    case 3:
                        choose_operation(operation, A, C, D);
                        break;
                    }
                    break;
                case 2:
                    switch (set_number2)
                    {
                    case 1:
                        choose_operation(operation, B, A, D);
                        break;
                    case 2:
                        choose_operation(operation, B, B, D);
                        break;
                    case 3:
                        choose_operation(operation, B, C, D);
                        break;
                    }
                    break;
                case 3:
                    switch (set_number2)
                    {
                    case 1:
                        choose_operation(operation, C, A, D);
                        break;
                    case 2:
                        choose_operation(operation, C, B, D);
                        break;
                    case 3:
                        choose_operation(operation, C, C, D);
                        break;
                    }
                }
            }
            else
            {
                switch (set_number)
                {
                case 1:
                    D.Сomplement(A);
                    break;
                case 2:
                    D.Сomplement(B);
                    break;
                case 3:
                    D.Сomplement(C);
                    break;
                }
            }
            D.print();
            D.clear();
            break;
        case 4:
            handle_string(A, B, C);
            break;
        }
    } while (switch_n != 0);
}

int main()
{
    setlocale(LC_ALL, "Rus");
    SetConsoleCP(1251); SetConsoleOutputCP(1251);
    system("color F0");
    srand(time(NULL));
    int lb, ub;

    cout << "Введите нижнюю границу универсума: ";
    lb = input_integer();
    cout << "Введите верхнюю границу универсума: ";
    ub = input_integer();
    if (ub < lb)
        swap(lb, ub);

    Set::set_lower_bound(lb);
    Set::set_upper_bound(ub);

    menu();

    return 0;
}