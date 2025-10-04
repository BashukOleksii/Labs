#include "Worker.h"
#include "Engineer.h"
#include "Administration.h"
#include "List.h"

int main() {
	setlocale(0, "UKR");

	Cadr* worker = new Worker("Name1",2020,"Hight",10,1);
	Cadr* engineer = new Engineer("Name2",2010,"Mega","Master",100);
	Cadr* administration = new Administration("Name3",2025,"Normal","Master",10);

	Cadr::Shapka();
	worker->Print();
	engineer->Print();
	administration->Print();

	cout << "Виведення списку" << endl;
	List::Show();

	cout << "Використання iнкремента та декремента: " << endl;
	++*worker;
	++(++(++(*engineer)));
	--*administration;

	List::Show();

	cout << "Додавання пустого ерез функцiю." << endl;
	Cadr* empty = new Worker();
	empty->Add();
	List::Show();


	cout << "Додавання масиву з п'яти робiтникiв" << endl;

	Cadr* workers[5];

	for (int i = 0; i < 5; i++) {
		workers[i] = new Administration();
		workers[i]->Init();
		workers[i]->Add();
	}

	List::Show();

	cout << "Введiть iм'я для пошуку: " << endl;

	string name; getline(cin, name);

	List::Find(name);



}