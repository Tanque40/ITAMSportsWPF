using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraCientPlus
{
    class ControladorPrincipal
    {
        public static String MCMult(string expre)
        {
            expre = eliminaEspacios(expre);
            if (valSerieG(expre))
            {
                int[] conv = convierteSG(expre);
                return "" + MCMult(Convert.ToInt32(conv[0]), Convert.ToInt32(conv[1]));
            }//if
            else
                return "Para esta funcion se deben insertar datos en la forma: int . int";
        }//method

        private static int MCMult(int a, int b)
        {
            int min, i;
            if (a < b)
            {
                int temp = b;
                b = a;
                a = temp;
            }//if
            min = a;
            Console.WriteLine("min"+min);
            i = 2;
            while (i <= b && !(min % a == 0 && min % b == 0))
            {
                Console.WriteLine(min);
                min +=a;
                i++;
                Console.WriteLine(min);
            }//while
                

            return min;
        }//method

        public static String MCDiv(string expre)
        {
            expre = eliminaEspacios(expre);
            if (valSerieG(expre))
            {
                int[] conv = convierteSG(expre);
                return "" + MCDiv(Convert.ToInt32(conv[0]), Convert.ToInt32(conv[1]));
            }//if
            else
                return "Para esta funcion se deben insertar datos en la forma: int . int";
        }//method

        private static int MCDiv(int a, int b)
        {
            int max;
            if (b > a)
            {
                int temp = b;
                b = a;
                a = temp;
            }//if
            max = b;
            while (max > 1 && !(a % max == 0 && b % max == 0))
                max--;
            return max;

        }//method

        public static String serieG(String g)
        {
            g = eliminaEspacios(g);
            if (valSerieG(g))
            {
                int[] conv = convierteSG(g);
                int bas = conv[0], num = conv[1];
                string res = "";
                res = serieG(1, bas, num, res);
                return res;
            }//if
            else
                return "Para esta funcion se deben insertar datos en la forma: int . int";
        }//method

        private static String serieG(int a, int bas, int num, string res)
        {
            int s = Convert.ToInt32(Math.Floor(Math.Pow(num, Convert.ToDouble(a))));
            res += s;
            res += " ";
            if (a < bas)
                return serieG(a + 1, bas, num, res);
            else
                return res;
        }//method

        private static Boolean valSerieG(string s)
        {
            Boolean flag = true;
            int i = 0, cont = 0;
            while(flag && i < s.Length)
            {
                if (!(s[i] < '0' || s[i] > '9'))
                    i++;
                else
                    if (s[i] == '.')
                    {
                        i++;
                        cont++;
                    }//if
                    else
                        flag = false;
            }//while
            return flag && cont == 1;
        }//method

        private static int[] convierteSG(string s)
        {
            Console.WriteLine(s.IndexOf('.'));
            int a = int.Parse(s.Substring(0, s.IndexOf('.'))), b = int.Parse(s.Substring(s.IndexOf('.') + 1));
            int[] res = {a,b};
            return res;
        }//method

        public static String fibonacci(String s)
        {
            s = eliminaEspacios(s);
            if (valFibo(s))
            {
                int num = int.Parse(s);
                string res = "";
                res = fibonacci2(0,1,1,num,res);                
                return res;
            }//if
            else
                return "Solo se aceptan numeros para esta funcion";
        }//method

        private static String fibonacci2(int a, int b, int cont, int num, string res)
        {
            res += a;
            res += " ";
            if (cont < num)
                return fibonacci2(b, a + b, cont + 1, num, res);
            else
                return res;
        }//method

        public static Boolean valFibo(String s)
        {
            int i = 0;
            Boolean flag = true;
            while (i < s.Length && flag)
            {
                if (s[i] < '0' || s[i] > '9')
                    flag = false;
                i++;
            }//while
            return flag;
        }//method


        public static String resuelve(String expre)
        {
            if (expre == null)
                return expre;
            expre = eliminaEspacios(expre);
            if (validez(expre))
            {
                expre = toPostfix(expre);
                return "" + resuelvePf(stringPila(expre));
            }//if
            else
                return "Expresion no valida";
        }//method

        public static String eliminaEspacios(String expre) => expre.Replace(" ", "");        

        public static Boolean operador(char c) => (c == '+' || c == '-' || c == '*' || c == '/');

        public static Boolean validez(String expre)
        {
            Boolean flag = true;
            int pos = 0, parentesis = 0;
            char c;

            //revisa que el primer ccaracter y el ultimo caracter no sean operadores
            //se hace una excepcion con el menos al principio ya que pude indicar un numero negativo
            flag = (expre[0] == '-' || char.IsNumber(expre[0]) || char.IsPunctuation(expre[0])) && (char.IsNumber(expre[expre.Length - 1]) || char.IsPunctuation(expre[expre.Length - 1]));


            while (pos<expre.Length && flag)
            {
                c = expre.ElementAt(pos);
                if ((c >= '(' && c <= '9') || c == '^')
                {
                    if (operador(c))
                    {
                        if (operador(expre[pos + 1]))
                            flag = false;
                    }//if
                    else
                    {
                        if (c == '(')
                            parentesis++;
                        else
                            if (c == ')')
                            parentesis--;
                    }//else
                    pos++;
                }//if                                                  
                else
                    flag = false;
            }//while
            

            return flag && parentesis == 0;
        }//method

        public static int jerarquia(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
            }
            return -1;
        }//method

        public static String toPostfix(String cad)
        {
            String res = "";
            LkStack<char> pila = new LkStack<char>();
            char c;

            for (int i = 0; i < cad.Length; i++)
            {
                c = cad.ElementAt(i);
                if (char.IsLetterOrDigit(c) || c == '.')
                    res += c;
                else
                {
                    if (res.Length >= 1)
                        if (res.ElementAt(res.Length - 1) != ' ')
                        {
                            res += " ";
                        }
                    if (c == '(')
                        pila.push(c);
                    else
                    {
                        if (c == ')')
                        {
                            while (!pila.isEmpty() && pila.peek() != '(')
                                res += pila.pop() + " ";
                            if (!pila.isEmpty() && pila.peek() == '(')
                                pila.pop();
                        }
                        else
                        {
                            while (!pila.isEmpty() && jerarquia(c) <= jerarquia(pila.peek()))
                                res += pila.pop() + " ";
                            pila.push(c);
                        }
                    }
                }
            }
            res += " ";
            while (!pila.isEmpty())
            {
                res += pila.pop() + " ";
            }
            return res;
        }//method

        public static double resuelvePf(LkStack<string> expresion)
        {
            double resp, aux1, aux2;
            char oper;
            LkStack<string> pila = new LkStack<string>();
            resp = Convert.ToDouble(expresion.peek());
            while (!expresion.isEmpty())
            {
                try { 
                    Convert.ToDouble(expresion.peek());
                    pila.push(expresion.pop()); 
                }
                catch
                {
                    aux1 = Convert.ToDouble(pila.pop());
                    aux2 = Convert.ToDouble(pila.pop());
                    oper = (expresion.pop().ElementAt(0));
                    switch (oper)
                    {
                        case '+':
                            resp = aux2 + aux1;
                            break;
                        case '-':
                            resp = aux2 - aux1;
                            break;
                        case '*':
                            resp = aux2 * aux1;
                            break;
                        case '/':
                            resp = aux2 / aux1;
                            break;
                    }
                    string t = "" + resp;
                    pila.push(t);
                }
            }
            return resp;
        }//method
        public static LkStack<string> stringPila(String cadena)
        {
            String[] aux;
            Boolean ayuda;
            ayuda = true;
            LkStack<string> pila;
            int i;
            i = 0;
            while (i < cadena.Length && ayuda)
            {
                if (cadena.ElementAt(i) == '+' || cadena.ElementAt(i) == '-' || cadena.ElementAt(i) == '*' || cadena.ElementAt(i) == '/')
                    ayuda = false;
                i++;
            }
            pila = new LkStack<string>();
            if (ayuda)
            {
                pila.push(cadena);
                Console.WriteLine(pila.peek());
            }

            else
            {
                aux = cadena.Split(' ');
                for (i = aux.Length - 1; i >= 0; i--)
                {
                    switch (aux[i])
                    {
                        case "-":
                            pila.push("-");
                            break;
                        case "+":
                            pila.push("+");
                            break;
                        case "*":
                            pila.push("*");
                            break;
                        case "/":
                            pila.push("/");
                            break;
                        default:
                            pila.push(aux[i]);
                            break;
                    }//switch
                }//for
            }//else
            return pila;
        }//method

        //=========================terminan metodos de ventana principal========================

        //========================metodos ventana producto cruz=======================

        public static String prodCruz(string [,] vect)
        {
            try
            {
                //se convierte la matriz de String's a una matriz de int's
                int[,] valores = new int[vect.GetLength(0), vect.GetLength(1)];
                for (int i = 0; i < vect.GetLength(0); i++)
                {
                    for (int j = 0; j < vect.GetLength(1); j++)
                    {
                        valores[i, j] = int.Parse(vect[i,j]);
                    }//for
                }//for
                int a = valores[0,1]*valores[1,2] - valores[0,2]*valores[1,1],
                    b = valores[0,2]*valores[1,0] - valores[0,0]*valores[1,2],
                    c = valores[0,0]*valores[1,1] - valores[0,1]*valores[1,0];
                return "( " + a + ", " + b + ", " + c + ")";

            }//try
            catch (FormatException)
            {
                return "Esta funcion solo acepta int's como componentes de los vectores";
            }//catch
        }//mehtod


    }//class
}//namespace
