using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculadoraCientPlus
{
    class LkStack <T>
    {
        private Nodo<T> inicio, top;
        private int count;

        public LkStack()
        {
            inicio = new Nodo<T>();
            top = inicio;
            count = 0;
        }//builder

        public void push(T element)
        {
            Nodo<T> nuevo = new Nodo<T>(element);
            top.setSig(nuevo);
            nuevo.setPrev(top);
            top = nuevo;
            count++;
        }//method

        public T peek() => top.getElement();

        public T pop()
        {
            if (top == inicio)
                return default(T);
            T res = top.getElement();
            top = top.getPrev();
            Nodo<T> nul = null;
            
            top.setSig(nul);
            return res;
        }//method

        public Boolean isEmpty() => top.getBlock();

        public int getCount() => count;

    }//class
}//namespace
