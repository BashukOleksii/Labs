#pragma once

#include "Cadr.h";
#include <vector>

class Department {
private:
	string name;
	vector <Cadr*> employees;

public:
	Department(string _name): name(_name){}
	Department() : name("None"){}

	void Add(Cadr* emp) {
		if (emp)
			employees.push_back(emp);
	}

	void Print() {

		if (employees.empty()) {
			cout << "Департамент поки щопорожній" << endl;
			return;
		}

		cout << "==================================================================" << endl;
		cout <<setw(20)<< "Департамент: " << name<<endl;
		cout << "==================================================================" << endl;

		Cadr::Shapka();

		for (const auto& emp : employees) 
			emp->Print();
	}

	void Remove(int id) {
		for (auto it = employees.begin(); it != employees.end(); it++) {

			if ((*it) != nullptr && (*it)->GetWorkId() == id) {
				employees.erase(it);
				cout << "Працівника виключено з департаменту"<<endl;
				return;
			}
		}

		cout << "За вказаним id не знайдено працівника" << endl;
	}

	void FindByName(string name) {

		if (employees.empty()) {
			cout << "В відділі ще немає працівників" << endl;
			return;
		}

		int count = 0;

		for (auto it = employees.begin(); it != employees.end(); it++) 
			if ((*it) != nullptr && (*it)->CompareName(name)) 
				count++;
			
		if (!count) {
			cout << "Робітників із вказаним ім'ям не знайдено" << endl;
			return;
		}

		Cadr::Shapka();
		for (auto it = employees.begin(); it != employees.end(); it++)
			if ((*it) != nullptr && (*it)->CompareName(name))
				(*it)->Print();


	}

	void Reform() {
		employees.clear();
		cout << "Відділ \"" << name << "\" розформовано" << endl;
	}

	void SetName() {
		cout << "Введіть назву віділу"; getline(cin, name);
	}

	string GetName() {
		return name;
	}

	int GetCountEmployee() {
		return employees.size();
	}

};