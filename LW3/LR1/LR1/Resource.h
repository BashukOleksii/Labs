#pragma once

#include "Edition.h"

class Resource : public Edition {
private:
	string ref;
	string anotation;

public:
	Resource(string title, string authorSurname, string Ref, string Anotation) : Edition(title, authorSurname) {
		ref = Ref;
		anotation = Anotation;

		type = "Resource";
	}

	
	Resource() : ref("None"), anotation("None") { type = "Resource"; }

	void Publish() override {
		cout << "–есурс опублiковано на сайтi." << endl;
	}

	void Print() override {
		Edition::Print();
		cout << setw(10) << "|" << setw(15) << "|" << setw(10) << "|" << setw(15) << "|" << setw(13) <<ref << " |" << setw(15) <<anotation << endl;
		Edition::ShowLine();
	}

	void Init() override {
		Edition::Init();
		cout << "¬ведiть назву посиланн€: "; getline(cin, ref);
		cout << "¬ведiть назву анотац≥ю: "; getline(cin, anotation);
	}
	

	virtual ~Resource() {}
};