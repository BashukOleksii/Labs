#include "Cadr.h"

int main() {

	setlocale(0, "UKR");

	Cadr cadr0; // Замовчування
	Cadr cadr1("Name", 1, 1); // Класичний
	Cadr cadr2 = cadr1; // Копіювання

	cout << "Виведення\n";
	cadr0.PrintCadr();
	cadr1.PrintCadr();
	cadr2.PrintCadr();

	cout << "\nГетери / Сетери" << endl;
	cadr0.setName();
	cadr0.setNum();
	cadr0.setRozr();

	cout << "Заповнений:\nIм'я: " << cadr0.getName() << "\nНомер цеху: " << cadr0.getNum() << "\nРозряд: " << cadr0.getRozr() << endl;

	cout << "\nМасив:" << endl;
	Cadr* array = new Cadr[5];

	for (int i = 0; i < 5; i++) 
		array[i].SetCadr();
	
	cout << "Заповнений масив:\n";

	for (int i = 0; i < 5; i++)
		array[i].PrintCadr();

	delete[] array;
	array = nullptr;

	
	cout << "\nКомпонентний вказiвник" << endl;

	void(Cadr:: * pointer)();
	pointer = &Cadr::PrintCadr;
	(cadr1.*pointer)();

	cout << "\nВказiвник на екземпляр" << endl;
		Cadr* p = &cadr1;
		p->PrintCadr();
}