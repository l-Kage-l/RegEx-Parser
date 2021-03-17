using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class ParsingExpression
    {
        public void Parsing(string expr)
        {
            char[] E = expr.ToCharArray();
            BinaryTree Parser = new BinaryTree();
            Parser.Root = new Node();
            char[] s = { 'w', 'W', 's', 'S', 'd', 'D', 'r', 'n', 't', 'f', 'e', 'v', 'a', 'A', 'Z', 'z', 'G', 'b', 'B' };
            int nrOfElements = 0;

            for (int i = 0; i < E.Length; i++)
            {
                Node firstNode = new Node();
                int counter = 0;
                if (E[i] == '[')
                {
                    firstNode.Data[counter] = '[';
                    counter++;
                    if (E[i + 1] == '^')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                    else if (Char.IsLetter(E[i + 1]) && E[i + 2] == '-' && Char.IsLetter(E[i + 3]) && E[i + 4] == ']')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                    else if (Char.IsNumber(E[i + 1]) && E[i + 2] == '-' && Char.IsNumber(E[i + 3]) && E[i + 4] == ']')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                }
                if (E[i] == '(')
                {
                    firstNode.Data[counter] = E[i];
                    counter++;
                }
                if (E[i] == ']' || E[i] == ')')
                {
                    firstNode.Data[counter] = E[i];
                    counter++;
                    nrOfElements++;
                }
                if (E[i] == '\u0022')
                {
                    firstNode.Data[counter] = E[i];
                    counter++;
                    for(int j=0; j < s.Length; j++)
                        if (E[i + 1] == s[j])
                        {
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            break;
                        }
                    if (E[i + 1] == 'p' || E[i + 1] == 'P')
                        if (E[i + 2] == '{')
                        {
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            while (E[i] != '}')
                            {
                                i++; firstNode.Data[counter] = E[i];
                                counter++;
                            }
                            i++; firstNode.Data[counter] = E[i];
                            counter++;

                        }
                        else if (Char.IsNumber(E[i + 1]) && Char.IsNumber(E[i + 2]) && Char.IsNumber(E[i + 3]))
                        {
                            i++; firstNode.Data[counter] = E[i];
                            counter++; 
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;


                        }
                        else if (E[i + 1] == 'x' && Char.IsNumber(E[i + 2]) && Char.IsNumber(E[i + 3]))
                        {
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;

                        }
                        else if (E[i + 1] == 'u' && Char.IsNumber(E[i + 2]) && Char.IsNumber(E[i + 3]) && Char.IsNumber(E[i + 4]) && Char.IsNumber(E[i + 5]))
                        {
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;
                            i++; firstNode.Data[counter] = E[i];
                            counter++;

                        }
                    nrOfElements++;
                }
                if (Char.IsLetter(E[i]) || Char.IsNumber(E[i]))
                {
                    if (E[i + 1] == '*' || E[i + 1] == '+' || E[i + 1] == '?')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                    else if (E[i + 1] == '{' && Char.IsNumber(E[i + 2]) && E[i + 3] == '}')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                    else if (E[i + 1] == '{' && Char.IsNumber(E[i + 2]) && E[i + 3] == ',' && E[i + 4] == '}')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                    else if (E[i + 1] == '{' && Char.IsNumber(E[i + 2]) && E[i + 3] == ',' && Char.IsNumber(E[i + 4]) && E[i + 5] == '}')
                    {
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                        i++; firstNode.Data[counter] = E[i];
                        counter++;
                    }
                    nrOfElements++;
                    firstNode.Index = nrOfElements;
                    Parser.Add(firstNode);
                }
                Parser.TraverseInOrder(Parser.Root);
            }
        }
    }
}
