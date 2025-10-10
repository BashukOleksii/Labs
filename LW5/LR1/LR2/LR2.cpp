#include "Worker.h"
#include "Engineer.h"
#include "Administration.h"
#include "List.h"
#include <Windows.h>
#include "Deepartment.h"

int main() {
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);

	cout << "Створення об'єктів абстрактного класу за допомогою конструктора та виведення: " << endl;
	Cadr* worker = new Worker("Ернест",2020,"Ремонт електроніки","Професійна",10,1);
	Cadr* engineer = new Engineer("Тарас", 2010, "Вища","Налаштування електроніки",  "Електроніка", 50);
	Cadr* administration = new Administration("Євген",2025,"Управління працівниками","Вища","Керуючий",10);

	Cadr::Shapka();

		worker->Print();
		engineer->Print();
		administration->Print();

	// Створення департаменту та додавання
		Department dep("Технічний");
		dep.Add(worker);
		dep.Add(engineer);
		dep.Add(administration);

	cout << "\nРозрахування зарплати робітника: " << worker->GetSalary() << endl;
	cout << "Розрахування зарплати інженера: " << engineer->GetSalary() << endl;
	cout << "Розрахування зарплати адміністрації: " << administration->GetSalary() << endl;

	cout << "Використання iнкремента та декремента: " << endl;
	++*worker;
	++(++(++(*engineer)));
	--*administration;
	Register::Show();

	//"Створення за замовчуванням:";
	Cadr* empty = new Worker();
	dep.Add(empty);

	cout << "Додавання масиву з п'яти робiтникiв та виведення:" << endl;

	Cadr* workers[5];

	for (int i = 0; i < 5; i++) {
		workers[i] = new Worker();
		workers[i]->Init();
		dep.Add(workers[i]);
	}

	dep.Print();

	cout << "Пошук за ім'ям: " << endl;

	cout << "Введiть iм'я для пошуку: " << endl;
	string name; getline(cin, name);

	dep.FindByName(name);

	cout << "Кількість працівників: " << dep.GetCountEmployee() << endl;

	cout << "Переведення першого працівника" << endl;
	dep.Remove(1);
	Department dep1("Фінанси");
	dep1.Add(worker);
	dep1.Print();
	dep.Reform();
}