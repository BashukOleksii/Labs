#pragma once


#include "List.h"

Cadr::Cadr(string name, int enteredYear, string education) {
	this->name = name;
	this->enteredYear = enteredYear;
	NormalNum(this->enteredYear);
	this->education = education;
	Add();
}

Cadr::Cadr() : name("None"), enteredYear(0), education("None") {}

void Cadr::Add() {
	List::Add(this);
}

void Cadr::Shapka() {
	cout << setw(15) << "Iм'я |" << setw(10) << "Вступ |" << setw(10) << "Освiта |";
	cout << setw(15) << "Продукцiї |" << setw(10) << "Розряд |";
	cout << setw(15) << "Спецiалiзацiя |" << setw(10) << "Проєктiв |";
	cout << setw(15) << "Посада |" << setw(10) << "Пiдданих" << endl;

	PrintLine();
}

void Cadr::Init() {
		SetName();
		SetEducation();
		SetEnteredYear();
	cin.ignore();
}

void Cadr::SetName()
{
	cout << "Введiть iм'я: "; getline(cin, name);
}

void Cadr::SetEnteredYear()
{
	cout << "Введiть рiк вступу в компанiю: ";  cin >> enteredYear; NormalNum(enteredYear);
}

void Cadr::SetEducation()
{
	cout << "Введiть, яка освiта: "; getline(cin, education);
}

string Cadr::GetName()
{
	return name;
}

int Cadr::GetEnteredYear()
{
	return enteredYear;
}

string Cadr::GetEducation()
{
	return education;
}

bool Cadr::CompareName(string name)
{
	return this->name == name;
}

void Cadr::NormalNum(int& num) {
	while (num < 0) {
		cin >> num;

		if (num < 0)
			cout << "Некоректно введенне значення." << endl;
	}
}

void Cadr::PrintLine()
{
	for (int i = 0; i < 110; i++)
		cout << "-";
	cout << endl;
}


