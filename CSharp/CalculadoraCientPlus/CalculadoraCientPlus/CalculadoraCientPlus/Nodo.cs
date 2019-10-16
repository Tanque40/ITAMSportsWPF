using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientPlus
{
    class Nodo<T>
    {
        private T element;
        Nodo<T> prev, sig;
        Boolean block;

        public Nodo()
        {
            element = default(T);
            prev = null;
            sig = null;
            block = true;
        }//builder

        public Nodo(T elem)
        {
            element = elem;
            prev = null;
            sig = null;
            block = false;
        }//builder

        //Getters
        public Nodo<T> getSig() => sig;
        public Nodo<T> getPrev() => prev;
        public T getElement() => element;
        public Boolean getBlock() => block;

        //Setters
        public void setSig(Nodo<T> nodo)
        {
            sig = nodo;
        }//method
        public void setPrev(Nodo<T> nodo)
        {
            prev = nodo;
        }//method
        public void setElement(T elem)
        {
            element = elem;
        }//method

        

    }//class
}//namespace
