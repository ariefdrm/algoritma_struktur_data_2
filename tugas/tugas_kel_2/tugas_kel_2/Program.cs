using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading;
using System.Threading.Tasks;

namespace tugas_kel_2
{
    class Stacks
    {
        // Function to add element
        public static void push(ArrayList a, string input)
        {
            a.Add(input);
        }

        // Function to remove last element
        public static void pop(ArrayList a)
        {
            if (a.Count > 0)
            {
                a.RemoveAt(a.Count - 1);
            }
        }

        // function to clear all elements
        public static void clear(ArrayList a)
        {
            a.Clear();
        }

        // Function to print last element
        public static void peek(ArrayList a)
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
        // Initializing variables
        private string text = "";
        private ArrayList undoText = new ArrayList();
        private ArrayList redoText = new ArrayList();

        // Encapsulation for "TextInput"
        public string CurrentText
        {
            get { return text; } // return the value of "text"
            set { text = value; } // set the value of "text"
        }

        // Encapsulation for "UndoText"
        public ArrayList UndoTextInput
        {
            get { return undoText; } // return the value of "undoText"
            set { undoText = value; } // set the value of "undoText"
        }

        // Encapsulation for "RedoText"
        public ArrayList RedoTextInput
        {
            get { return redoText; } // return the value of "redoText"
            set { redoText = value; } // set the value of "redoText"
        }

        // Function to undo
        public void Undo(string currentText)
        {
            if (UndoTextInput.Count > 0) // Check if there are any elements in the UndoTextInput
            {
                push(RedoTextInput, currentText); // Add currentText to the RedoTextInput
                CurrentText = UndoTextInput[UndoTextInput.Count - 1].ToString(); // Set CurrentText to the last element in the UndoTextInput
                pop(UndoTextInput); // Remove the last element in the UndoTextInput
            }
            else
            {
                Console.WriteLine("Nothing to undo!");
                Console.ReadKey();
            }
        }

        // Function to redo
        public void Redo(string currentText)
        {
            if (RedoTextInput.Count > 0) // Check if there are any elements in the RedoTextInput
            {
                push(UndoTextInput, currentText); // Add currentText to the UndoTextInput
                CurrentText = RedoTextInput[RedoTextInput.Count - 1].ToString(); // Set CurrentText to the last element in the RedoTextInput
                pop(RedoTextInput); // Remove the last element in the RedoTextInput
            }
            else
            {
                Console.WriteLine("Nothing to redo!");
                Console.ReadKey();
            }
        }

        // Display output text
        public void DisplayCurrentText(string a)
        {
            Console.WriteLine("{0}", a, CurrentText); // Display the current text
        }

        // Display the content of the stack (for debugging purpose)
        public void DisplayStack(ArrayList a)
        {
            Console.WriteLine("+-------------------------+");
            for (int i = a.Count; i > 0; i--) // To print the elements in the stack
            {
                Console.WriteLine("| {0,-23} |", a[i - 1]);
            }
            Console.WriteLine("+-------------------------+");
        }

        // Function to get input
        public string GetInput(string input)
        {
            Console.Write(input); // For user to input
            return Console.ReadLine(); // Get the input
        }

        // Function to edit text
        public void Edit()
        {
            Console.Clear();
            Headers("EDIT TEXT");
            string newText = GetInput("Masukkan teks baru: "); // Input new text
            if (!string.IsNullOrWhiteSpace(newText))
            {
                push(UndoTextInput, CurrentText); // Add currentText to the UndoTextInput
                clear(RedoTextInput); // Remove all elements in the RedoTextInput

                CurrentText = newText; // Set CurrentText to the new text
            }
        }

        // Function to display debugging information
        public void Debugging()
        {
            Console.Clear();
            Console.Write("Current Text: {0}\n", CurrentText);
            Console.WriteLine();
            if (UndoTextInput.Count > 0)
            {
                Console.Write("Text yang diundo : \n");
                DisplayStack(UndoTextInput);
            }
            if (RedoTextInput.Count > 0)
            {
                Console.Write("Text yang diredo :  \n");
                DisplayStack(RedoTextInput);
            }

            Console.ReadKey();
        }

        // Header and Footer
        public void Headers(string headerName)
        {
            Console.WriteLine("======={0}=======", headerName);
            Console.WriteLine();
        }

        public void Footer()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // End of the header and footer

        // Display the menu
        public void DisplayMenu()
        {
            Console.Clear();
            Headers("Undo/Redo Text Editor"); // Display the header
            DisplayCurrentText("The current text is: "); // Display the current text
            Console.WriteLine();
            Console.WriteLine("[1] Edit\n[2] Undo\n[3] Redo\n[4] Exit"); // Print the menu
        }

        // Function to handle the choice
        public void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Edit(); // run the "Edit" function
                    break;
                case 2:
                    Undo(CurrentText); // run the "Undo" function
                    break;
                case 3:
                    Redo(CurrentText); // run the "Redo" function
                    break;
                case 4:
                    Environment.Exit(0); // Exit the program
                    break;
                case 5: // for debugging purpose
                    Debugging();
                    break;
            }
        }

        // Function to run the program
        public void Run()
        {
            Headers("Undo/Redo Text Editor"); // Display the header
            CurrentText = GetInput("Masukkan teks: "); // User input
            if (string.IsNullOrWhiteSpace(CurrentText)) // Check if the text is empty or just whitespace
            {
                Console.WriteLine("Teks tidak boleh kosong. Silahkan ulangi kembali.!!!");
                Console.ReadKey();
                Console.Clear();
                Run(); // Recall "Run" program if the input is empty of just whitespace
            }

            while (true)
            {
                DisplayMenu(); // Display the menu
                string choiceInput = GetInput("Masukkan pilihan: "); // User Input

                if (!int.TryParse(choiceInput, out int choice)) // Check if the input is integer and convert it in "choice" variable
                {
                    Console.WriteLine("Input harus berupa angka. Silahkan ulangi kembali.!!!"); // if the input is not integer
                    Console.ReadKey();
                }
                HandleChoice(choice); // handle the choice
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor tx = new TextEditor();
            tx.Run();
        }
    }
}
