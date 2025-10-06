#include "Worker.h"
#include "Engineer.h"
#include "Administration.h"
#include "List.h"
#include <Windows.h>

int main() {
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	cout << "Створення об'єктів абстрактного класу за допомогою конструктора та виведення: " << endl;
	Cadr* worker = new Worker("Ернест",2020,"Професійна",10,1);
	Cadr* engineer = new Engineer("Тарас", 2010, "Вища", "Електроніка", 50);
	Cadr* administration = new Administration("Євген",2025,"Вища","Керуючий",10);

	Cadr::Shapka();
		worker->Print();
		engineer->Print();
		administration->Print();

	cout << "Розрахування зарплати робітника: " << worker->GetSalary() << endl;
	cout << "Розрахування зарплати інженера: " << engineer->GetSalary() << endl;
	cout << "Розрахування зарплати адміністрації: " << administration->GetSalary() << endl;

	cout << "Використання iнкремента та декремента: " << endl;
	++*worker;
	++(++(++(*engineer)));
	--*administration;
	List::Show();

	cout << "Створення за замовчуванням:" << endl;
	Cadr* empty = new Worker();
	empty->Add();
	List::Show();


	cout << "Додавання масиву з п'яти робiтникiв та виведення:" << endl;

	Cadr* workers[5];

	for (int i = 0; i < 5; i++) {
		workers[i] = new Worker();
		workers[i]->Init();
		workers[i]->Add();
	}

	List::Show();

	cout << "Пошук за ім'ям: " << endl;

	cout << "Введiть iм'я для пошуку: " << endl;
	string name; getline(cin, name);
	List::Find(name);



}