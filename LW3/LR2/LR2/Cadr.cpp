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
	cout << setw(15) << "I�'� |" << setw(10) << "����� |" << setw(10) << "���i�� |";
	cout << setw(15) << "�������i� |" << setw(10) << "������ |";
	cout << setw(15) << "����i��i���i� |" << setw(10) << "�����i� |";
	cout << setw(15) << "������ |" << setw(10) << "�i������" << endl;

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
	cout << "����i�� i�'�: "; getline(cin, name);
}

void Cadr::SetEnteredYear()
{
	cout << "����i�� �i� ������ � ������i�: ";  cin >> enteredYear; NormalNum(enteredYear);
}

void Cadr::SetEducation()
{
	cout << "����i��, ��� ���i��: "; getline(cin, education);
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
			cout << "���������� �������� ��������." << endl;
	}
}

void Cadr::PrintLine()
{
	for (int i = 0; i < 110; i++)
		cout << "-";
	cout << endl;
}


