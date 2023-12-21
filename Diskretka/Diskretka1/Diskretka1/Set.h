#pragma once
#include <iostream>
#include <vector>
#include <string>
#include <climits>
using namespace std;

int input_integer()
{
	string input;
	cin >> input;
	bool is_integer = false;
	while (!is_integer)
	{
		for (int i = 0; i < input.length(); )
		{
			if ((input[i] >= '0' && input[i] <= '9') || input[i] == '-')
			{
				++i;
				is_integer = true;
			}
			else
			{
				cout << "Некорректный ввод! Попробуйте снова: ";
				cin >> input;
				i = 0;
				is_integer = false;
			}
		}
	}
	return stoi(input);
}

void check_number(int lower_bound, int upper_bound, int& value, string msg_repetitive = "Некоректный ввод! Попробуйте снова: ")
{
	if (lower_bound > upper_bound)
		swap(lower_bound, upper_bound);
	while (value < lower_bound || value > upper_bound)
	{
		cout << msg_repetitive;
		value = input_integer();
	}
}

class Set
{
	static int lower_bound, upper_bound;
public:
	vector <int> set;
	Set(void);
	Set(int n);
	~Set(void);

	static void set_lower_bound(int lb) { lower_bound = lb; }
	static void set_upper_bound(int ub) { upper_bound = ub; }
	static void get_lower_bound() { cout << "Нижняя граница: " << lower_bound << endl; }
	static void get_upper_bound() { cout << "Верхняя граница: " << upper_bound << endl; }

	void fill_set();
	void add_element(int el);
	void delete_element(int el);
	void print();
	void clear();

	Set operator =(const Set&);

	void Union(Set& A1, Set& A2); // U
	void Intersection(Set& A1, Set& A2); // ^
	void Subtraction(Set& A1, Set& A2); // "\"
	void SymmetrySubstraction(Set& A1, Set& A2); // "\\"
	void Сomplement(Set& A1); // ~
};

int Set::lower_bound = -5;
int Set::upper_bound = 5;

Set::Set()
{
	set.reserve(upper_bound - lower_bound + 1);
}

Set::~Set() {}

Set::Set(int n)
{
	cout << "Введите элементы множества: \n";
	int a;
	for (int i = 0;i < n;++i)
	{
		a = input_integer();
		set.push_back(a);
		if (a < lower_bound || a > upper_bound)
			set.pop_back();
		for (int j = 0; j < i; ++j)
		{
			if (set[j] == a)
			{
				set.pop_back();
			}
		}
	}
}

Set Set::operator =(const Set& A)
{
	if (&A == this) return *this;
	set = A.set;
	return*this;
}

void Set::fill_set()
{
	this->clear();
	int switch_fill, switch_condition, elements_count, x, el;

	cout << "Выберете способ заполнения:\n1 - случайное заполнение;\n2 - через условие;\n3 - вручную.\n";
	switch_fill = input_integer();
	check_number(1, 3, switch_fill);

	switch (switch_fill)
	{
	case 1:
		cout << "Введите кол-во элементов: ";
		elements_count = input_integer();
		while (elements_count > upper_bound - lower_bound + 1)
		{
			cout << "Слишком много элементов! Максимальное кол-во = " << (upper_bound - lower_bound + 1) << ". Попробуйте ввести ещё раз:";
			elements_count = input_integer();
		}
		for (int i = 0;i < elements_count;++i)
		{
			el = lower_bound + rand() % (upper_bound - lower_bound + 1);
			set.push_back(el);
			for (int j = 0; j < i; ++j)
			{
				if (set[j] == el)
				{
					set.pop_back();
					--i;
				}
			}
		}
		break;
	case 2:
		cout << "Выберете условие:\n1 - заполнить чётными, 2 - нечётными;\n"
			<< "3 - заполнить кратными x, 4 - некратными x;\n5 - заполнить положительными, 6 - заполнить отрицательными.\n";
		switch_condition = input_integer();
		check_number(1, 6, switch_condition);

		switch (switch_condition)
		{
		case 1:
			for (int i = lower_bound; i <= upper_bound; ++i)
			{
				if (i % 2 == 0)
					set.push_back(i);
			}
			break;
		case 2:
			for (int i = lower_bound; i <= upper_bound; ++i)
			{
				if (i % 2 != 0)
					set.push_back(i);
			}
			break;
		case 3:
			cout << "Введите x: ";
			x = input_integer();
			for (int i = lower_bound; i <= upper_bound; ++i)
			{
				if (i % x == 0)
					set.push_back(i);
			}
			break;
		case 4:
			cout << "Введите x: ";
			x = input_integer();
			for (int i = lower_bound; i <= upper_bound; ++i)
			{
				if (i % x != 0)
					set.push_back(i);
			}
			break;
		case 5:
			if (upper_bound > 0)
			{
				if (lower_bound > 0)
				{
					for (int i = lower_bound; i <= upper_bound; ++i)
						set.push_back(i);
				}
				else
				{
					for (int i = 1; i <= upper_bound; ++i)
						set.push_back(i);
				}
			}
			break;
		case 6:
			if (lower_bound < 0)
			{
				if (upper_bound < 0)
				{
					for (int i = lower_bound; i <= upper_bound; ++i)
						set.push_back(i);
				}
				else
				{
					for (int i = lower_bound; i <= -1; ++i)
						set.push_back(i);
				}
			}
			break;
		}
		break;
	case 3:
		cout << "Введите кол-во элементов: ";
		elements_count = input_integer();
		while (elements_count > upper_bound - lower_bound + 1 || elements_count < 0)
		{
			cout << "Некорректный ввод! Максимальное кол-во элементов = " << (upper_bound - lower_bound + 1) << ". Попробуйте ввести ещё раз:";
			elements_count = input_integer();
		}
		cout << "Введите элементы множества: \n";
		for (int i = 0;i < elements_count;++i)
		{
			el = input_integer();
			check_number(lower_bound, upper_bound, el, "Это значение не принадлежит универсуму! Введите число снова: ");
			set.push_back(el);
			for (int j = 0; j < i; ++j)
			{
				if (set[j] == el)
				{
					set.pop_back();
					cout << "Вы ввели повторяющееся значение! Введите число снова: ";
					--i;
				}
			}
		}
		break;
	}
}

void Set::print()
{
	cout << '{';
	for (auto it = set.begin();it != set.end();++it)
	{
		cout << *it;
		if (it + 1 != set.end())
		{
			cout << ", ";
		}
	}
	cout << '}' << endl;
}

void Set::add_element(int el)
{
	set.push_back(el);
	if (el < lower_bound || el > upper_bound)
		set.pop_back();
	for (int i = 0; i < set.size() - 1; ++i)
	{
		if (set[i] == el)
		{
			set.pop_back();
		}
	}
}

void Set::delete_element(int el)
{
	for (auto it = set.begin();it != set.end();++it)
	{
		if (*it == el)
		{
			set.erase(it);
			--it;
		}
	}
}

void Set::clear()
{
	set.clear();
}

//---OPERATIONS---//

void Set::Union(Set& A1, Set& A2)
{
	for (auto it = A1.set.begin();it != A1.set.end();++it)
		this->add_element(*it);
	for (auto it = A2.set.begin();it != A2.set.end();++it)
		this->add_element(*it);
}

void Set::Intersection(Set& A1, Set& A2)
{
	for (auto it1 = A1.set.begin();it1 != A1.set.end();++it1)
	{
		for (auto it2 = A2.set.begin(); it2 != A2.set.end();++it2)
		{
			if (*it1 == *it2)
			{
				this->set.push_back(*it1);
			}
		}
	}
}

void Set::Subtraction(Set& A1, Set& A2)
{
	bool is_include = false;
	for (auto it1 = A1.set.begin();it1 != A1.set.end();++it1)
	{
		for (auto it2 = A2.set.begin(); it2 != A2.set.end();++it2)
		{
			if (*it1 == *it2)
				is_include = true;
		}
		if (!is_include)
			this->set.push_back(*it1);
		is_include = false;
	}
}

void Set::SymmetrySubstraction(Set& A1, Set& A2)
{
	bool is_include = false;
	for (auto it1 = A1.set.begin();it1 != A1.set.end();++it1)
	{
		for (auto it2 = A2.set.begin(); it2 != A2.set.end();++it2)
		{
			if (*it1 == *it2)
				is_include = true;
		}
		if (!is_include)
			this->set.push_back(*it1);
		is_include = false;
	}
	is_include = false;
	for (auto it2 = A2.set.begin();it2 != A2.set.end();++it2)
	{
		for (auto it1 = A1.set.begin(); it1 != A1.set.end();++it1)
		{
			if (*it2 == *it1)
				is_include = true;
		}
		if (!is_include)
			this->set.push_back(*it2);
		is_include = false;
	}
}

void Set::Сomplement(Set& A1)
{
	bool is_include = false;
	for (int i = lower_bound;i <= upper_bound; ++i)
	{
		for (auto it = A1.set.begin(); it != A1.set.end();++it)
		{
			if (i == *it)
				is_include = true;
		}
		if (!is_include)
			this->set.push_back(i);
		is_include = false;
	}
}