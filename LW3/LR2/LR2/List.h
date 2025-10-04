#pragma once

#include "Cadr.h"

class Node {
public:
	Cadr* people;
	Node* next;

	Node(Cadr* c) : people(c), next(nullptr) {}

};

class List {
private:
	static Node* head;
	static bool HasName(string name);

public:
	static void Add(Cadr* cadr);
	static void Delete();
	static void Show();
	static void Find(string name);
	static void Clear();

};