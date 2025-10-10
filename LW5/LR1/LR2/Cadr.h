#pragma once

#include <iostream>
#include <string>
#include "ServiceRecord.h"

using namespace std;

class Register;

class Cadr {
protected:
	string name;
	SRecord record;
	string education;
public:


	Cadr(string name, int enteredYear, string primarySkill, string education);

	Cadr();


	void Add();

	virtual void Print();




	virtual double GetSalary() = 0;

	virtual void Work() = 0;




	virtual void Init();





	void SetName();

	void SetEducation();


	int GetWorkId();

	string GetName();

	string GetEducation();

	bool CompareName(string name);



	virtual Cadr& operator++() = 0;
	virtual Cadr& operator--() = 0;




protected:
	void NormalNum(int& num);

	void PrintFatLine(bool endl);
	

};

