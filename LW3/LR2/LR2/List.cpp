	#include "List.h"

	Node* List::head = nullptr;

	void List::Add(Cadr* cadr) {

		Node* newNode = new Node(cadr);

		if (!head)
			head = newNode;
		else {

			Node* c = head;
			while (c->next)
				c = c->next;

			c->next = newNode;

		}
	}

	void List::Delete() {

		if (!head)
			return;

		if (!head->next) {
			delete head->people;
			delete head;
			head = nullptr;
		}
		else {
			Node* c = head, * last = head->next;
			while (last->next) {
				c = last;
				last = last->next;
			}

			delete last->people;
			delete last;

			c->next = nullptr;
		}
	}

	void List::Show() {

		if (!head)
			return;

		Cadr::Shapka();
		Node* c = head;

		while (c) {
			c->people->Print();
			c = c->next;
		}
	}



	bool List::HasName(string name) {

		bool find = false;

		Node* c = head;

		while (c) {
			if (c->people->CompareName(name))
				find = true;
			c = c->next;
		}

		return find;

	}

	void List::Find(string name)
	{
		if (!HasName(name)) {
			cout << "¬казаних елементiв не знайдено." << endl;
			return;
		}

		Cadr::Shapka();

		Node* c = head;

		while (c)
		{
			if (c->people->CompareName(name))
				c->people->Print();
			c = c->next;
		}
	}

	void List::Clear()
	{
		while (head)
			Delete();

	}
