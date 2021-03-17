using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Checker
    {
        int x;
        public Checker()
        {

        }
        public Checker(string k)
        {
            this.x = checkRegex(k);
        }
        public int checkRegex(string expr)
        {
            char[] E = expr.ToCharArray();
            int i = 0;
            int cp1 = 0, cp2 = 0; // cp1 - paranteze stg, cp2-paranteze dr
            char[] s = { 'w', 'W', 's', 'S', 'd', 'D', 'r', 'n', 't', 'f', 'e', 'v', 'a', 'A', 'Z', 'z', 'G', 'b', 'B' }; //chestiile de dupa '\'
            while (i < E.Length)
            {
                if (E[i] == '[')
                {
                    cp1++;
                    if (E[i + 1] == '^')
                    {
                        ;
                    }
                    else if (Char.IsLetter(E[i + 1]) && E[i + 2] == '-' && Char.IsLetter(E[i + 3]) && E[i + 4] == ']') // [a-z] daca e de forma asta
                    {
                        ;
                    }
                    else if (Char.IsNumber(E[i + 1]) && E[i + 2] == '-' && Char.IsNumber(E[i + 3]) && E[i + 4] == ']') // [1-9] daca e de forma asta
                    {
                        ;
                    }
                    else
                    {
                        return 0;
                    }
                }
                if (E[i] == '(')
                    cp1++;
                if (E[i] == ']' || E[i] == ')')
                    cp2++;
                if (E[i] == '\u0022')
                {
                    int j = 0;
                    while (j < s.Length)
                        if (E[i + 1] == s[j]) // daca dupa '\' ii una din lit din vectoru ala
                        {
                            ;
                        }
                    if (E[i + 1] == 'p' || E[i + 1] == 'P')
                        if (E[i + 2] == '{') ;

                        else if (Char.IsNumber(E[i + 1]) && Char.IsNumber(E[i + 2]) && Char.IsNumber(E[i + 3])) // daca e '\octal'
                        {
                            ;
                        }
                        else if (E[i + 1] == 'x' && Char.IsNumber(E[i + 2]) && Char.IsNumber(E[i + 3])) // daca e '\xhex' 
                        {
                            ;
                        }
                        else if (E[i + 1] == 'u' && Char.IsNumber(E[i + 2]) && Char.IsNumber(E[i + 3]) && Char.IsNumber(E[i + 4]) && Char.IsNumber(E[i + 5])) // daca e '\uunicode'
                        {
                            ;
                        }
                        else
                        {
                            return 0;
                        }
                }
                if (Char.IsLetter(E[i]) || Char.IsNumber(E[i]))
                {
                    if (E[i + 1] == '*' || E[i + 1] == '+' || E[i + 1] == '?')
                    {
                        ;
                    }
                    else if (E[i + 1] == '{' && Char.IsNumber(E[i + 2]) && E[i + 3] == '}')
                    {
                        ;
                    }
                    else if (E[i + 1] == '{' && Char.IsNumber(E[i + 2]) && E[i + 3] == ',' && E[i + 4] == '}')
                    {
                        ;
                    }
                    else if (E[i + 1] == '{' && Char.IsNumber(E[i + 2]) && E[i + 3] == ',' && Char.IsNumber(E[i + 4]) && E[i + 5] == '}')
                    {
                        ;
                    }
                   
                }

                i++;
            }
            if (cp1 != cp2)
                return 0;
            return 1;
        }
    }
}
