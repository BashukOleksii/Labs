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
	cout << setw(20) << "Name |" << setw(20) << "Education |";
	cout << setw(4) << "Id |" << setw(10) << "Status |" << setw(5) << "Year |" << setw(30) << "PrimarySkill | ";

	cout << setw(5) << "Rozr |" << setw(8) << "CountW |";

	cout << setw(15) << "Spec |" << setw(8) << "CountP |";
	
	cout << setw(15) << "Position |" << setw(8) << "CountH" << endl;

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
	for (int i = 0; i < 115; i++)
		cout << "-";
	cout << endl;
}


