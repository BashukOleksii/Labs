#pragma once

#include "Edition.h"

class Node {
public:
	Edition* e;
	Node* next;

	Node(Edition* ed) : e(ed), next(nullptr) {}
};

class List {
private:
	static Node* head;

public:
	static void Add(Edition* e);
	static void Delete();
	static bool HasSurname(string surname);
	static void Find(string surname);
	static void Show();
	static void Clear();


};
