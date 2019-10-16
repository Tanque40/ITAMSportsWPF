using System;
namespace CalculadoraCientPlus
{

    public class Node<T>
    {
        private T element;
        Node<T> prev, sig;

        public Node(T elem)
        {
            element = elem;
            prev = null;
            sig = null;
        }//builder

        //Getters
        public Node<T> getSig() => sig;
        public Node<T> getPrev() => prev;
        public T getElement() => element;

        //Setters
        public void setSig(Node<T> nodo)
        {
            sig = nodo;
        }//method
        public void setPrev(Node<T> nodo)
        {
            orev = nodo;
        }//method
        public void setElement(T elem)
        {
            element = elem;
        }//method


    }//class

}//namesoace
