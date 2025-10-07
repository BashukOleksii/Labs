#include "D4.h"
#include <Windows.h>

int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	cout << "Створення об'єкту через консруктор: " << endl;

	D4 d4 = D4(10, 12.5777, 1, 123981990, 11.11, 'A');

	B1::Shapka();
	d4.Print();

	cout << "Заповнення полів вручну: " << endl;
	d4.Init();

	B1::Shapka();
	d4.Print();

	cout << "Виклик деструкторів:" << endl;

}


