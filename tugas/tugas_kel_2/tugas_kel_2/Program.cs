using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugas_kel_2
{
    class Stacks
    {
        public void push(ArrayList a, string input)
        {
            a.Add(input);
        }

        public void pop(ArrayList a)
        {
            if (a.Count > 0)
            {
                a.RemoveAt(a.Count - 1);
            }
        }

        public void clear(ArrayList a)
        {
            a.Clear();
        }

        public void peek(ArrayList a)
        {
            if (a.Count > 0)
            {
                Console.Write("Last Element: " + a[a.Count - 1].ToString());
            }
            else
            {
                Console.WriteLine("Nothing in Stack!");
            }
        }
    }

    class TextEditor : Stacks
    {
        private string text = "";
        private ArrayList undoText = new ArrayList();
        private ArrayList redoText = new ArrayList();

        // Encapsulation for "TextInput"
        public string CurrentText
        {
            get { return text; }
            set { text = value; }
        }

        // Encapsulation for "UndoText"
        public ArrayList UndoTextInput
        {
            get { return undoText; }
            set { undoText = value; }
        }

        // Encapsulation for "RedoText"
        public ArrayList RedoTextInput
        {
            get { return redoText; }
            set { redoText = value; }
        }

        // Function to undo
        public void Undo(string currentText)
        {
            if (UndoTextInput.Count > 0)
            {
                push(RedoTextInput, currentText);
                CurrentText = UndoTextInput[UndoTextInput.Count - 1].ToString();
                pop(UndoTextInput);
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
            }
        }

        // Function to redo
        public void Redo(string currentText)
        {
            if (RedoTextInput.Count > 0)
            {
                push(UndoTextInput, currentText);
                CurrentText = RedoTextInput[RedoTextInput.Count - 1].ToString();
                pop(RedoTextInput);
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
            }
        }

        // Display output text
        public void Display()
        {
            Console.WriteLine(CurrentText);
        }

        // Function to get input
        public string GetInput(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        // Function to edit text
        public void Edit()
        {
            Console.Clear();
            string newText = GetInput("Masukkan teks baru: ");

            push(UndoTextInput, CurrentText);
            clear(RedoTextInput);

            CurrentText = newText;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor tx = new TextEditor();
            string currentText = tx.GetInput("Input: ");
            tx.CurrentText = currentText;

            atas:
            Console.Clear();
            Console.WriteLine("[1] Edit\n[2] display\n[3] Undo\n[4] Redo\n[5] Exit");
            string choice = tx.GetInput("Choose: ");
            int choiceInt = int.Parse(choice);

            switch (choiceInt)
            {
                case 1:
                    tx.Edit();
                    break;
                case 2:
                    Console.Clear();
                    tx.Display();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    tx.Undo(tx.CurrentText);
                    break;
                case 4:
                    Console.Clear();
                    tx.Redo(tx.CurrentText);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                case 6: // for debugging perpose
                    Console.Write("Current Text: {0}\n", tx.CurrentText);
                    if (tx.UndoTextInput.Count > 0)
                    {
                        Console.Write("Text yang diundo: ");
                        Console.WriteLine(tx.UndoTextInput[tx.UndoTextInput.Count - 1]);
                    }
                    if (tx.RedoTextInput.Count > 0)
                    {
                        Console.Write("Text yang diredo: ");
                        Console.WriteLine(tx.RedoTextInput[tx.RedoTextInput.Count - 1]);
                    }
                    Console.ReadKey();
                    break;
            }

            goto atas;
        }
    }
}
