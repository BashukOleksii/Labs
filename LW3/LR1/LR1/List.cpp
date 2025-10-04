#pragma once

#include "List.h"

Node* List::head = nullptr;

void List::Add(Edition* e) {

	if (head == nullptr)
		head = new Node(e);
	else {
		Node* c = head;

		while (c->next)
			c = c->next;

		c->next = new Node(e);

	}
}

void List::Delete() {

	if (!head)
		return;

	if (!head->next) {
		delete head->e;
		delete head;
		head = nullptr;
	}
	else {
		Node* last, * pre;
		pre = head;
		last = head->next;

		while (last->next) {
			pre = last;
			last = last->next;
		}

		delete last->e;
		delete last;

		pre->next = nullptr;
	}
	
}

bool List::HasSurname(string surname) {

	Node* c = head;

	while (c) {
		if (c->e->IsFind(surname))
			return true;
		c = c->next;
	}
	
	return false;
	
}

void List::Find(string surname) {

	if (!HasSurname(surname)) {
		cout << "Дiяльностi роботи вказаного автора не знайдено." << endl;
		return;
	}

	Node* c = head;

	Edition::Shap();
	while (c) {
		if (c->e->IsFind(surname)) 
			c->e->Print();
		c = c->next;
	}
	
	
	
}

void List::Show() {

	if (!head)
		return;

	Node* c = head;
	
	Edition::Shap();

	while (c) {
		c->e->Print();
		c = c->next;
	}
}

void List::Clear() {

	while(head)
		Delete();
}