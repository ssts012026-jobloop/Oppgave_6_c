using System;
using System.Collections.Generic;

namespace Testapp;

     public class TestStack<T> where T : class // T er like informasjonen som kommer fra classen
    {
        private readonly List<T> _items = new List<T>(); // stacken
        public int AntallItems => _items.Count; // nummeret på tingene i stacken

         public IEnumerable<T> Items => _items.AsReadOnly(); // lager ein liste som bare kan endres fra insiden av stacken, med push og pop

        public void Push(T item) // for å legge til noe i stacken
        {
            if (item == null) // feilmelding
                throw new ArgumentNullException(nameof(item), "Stacken godtar ikke null-verdier.");
            
            _items.Add(item); // legger til en ting i stacken
        }

        public T Pop() // for å ta vekk noe fra stacken
        {
            if (_items.Count == 0) // feilmelding
                throw new InvalidOperationException("Stacken er tom");

            int lastIndex = _items.Count -1; // fjerner en ting i stacken siden count teller ellementer i listen og ikkje plasseringen i listen trenger den -1
            T item = _items[lastIndex]; // T er siste tingen i listo
            _items.RemoveAt(lastIndex); // fjerner siste tingen fra listo
            return item; // sender ut siste 
        }

        public T Peek() // ser på den øverste tingen i stacken
        {
            if (_items.Count == 0) // feilmelding
                throw new InvalidOperationException ("Stacken er tom");

            return _items[_items.Count - 1]; // teller lokasjonen i listen, trenger -1 siden den teller lengen på listen og ikkje plasseringen. Plasseringen starter på 0 menst lengden starter på 1
        }
        
       public void Tøm() => _items.Clear(); // tømmer listen

    }

