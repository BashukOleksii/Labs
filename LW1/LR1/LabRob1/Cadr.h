#pragma once

#include <iostream>
#include <string>

using namespace std;
class Cadr
{
    private:
		string name;
		int number;
		int rozr;

	public:
		Cadr();
		Cadr(string n, int num, int r);
		Cadr(const Cadr&);
		~Cadr(void);

		string getName();
		void setName();

		int getNum();
		void setNum();

		int getRozr();
		void setRozr();

		void SetCadr();
		void PrintCadr();

};

