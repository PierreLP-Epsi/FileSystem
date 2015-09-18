using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string Commande;
            string[] listCommande;
            Directory fileSystem = new Directory("FileSystem", null);
            File current = fileSystem;
            

            for (int i = 0; i < i + 10; i++)
            {
                Console.Write(current.getPath() + " > ");
                Commande = Console.ReadLine();
                listCommande = Commande.Split(' ');
                
                if (listCommande[0] != "mkdir" && listCommande[0] != "create" &&
                    listCommande[0] != "cd" && listCommande[0] != "rename" &&
                    listCommande[0] != "search" && listCommande[0] != "delete" &&
                    listCommande[0] != "path" && listCommande[0] != "ls" && listCommande[0] != "root" &&
                    listCommande[0] != "parent" && listCommande[0] != "file" && listCommande[0] != "directory" &&
                    listCommande[0] != "name" && listCommande[0] != "chmod" && listCommande[0] != "exit")
                {
                    Console.WriteLine("Commande inconnue, veuillez réessayer");
                }

                // Petit Bonus
                if (listCommande[0] == "exit")
                {
                    Program.exit();
                }

                if (listCommande[0] == "mkdir")
                {
                    Console.WriteLine(current.mkdir(listCommande[1]));
                }

                if (listCommande[0] == "create")
                {
                    Console.WriteLine(current.createNewFile(listCommande[1]));
                }

                if (listCommande[0] == "cd")
                {
                    current = current.cd(listCommande[1]);
                }

                if (listCommande[0] == "rename")
                {
                    Console.WriteLine(current.renameTo(listCommande[1], listCommande[2]));
                }

                if (listCommande[0] == "search")
                {
                    Console.WriteLine("Commande reconnue et non fonctionnelle");
                }

                if (listCommande[0] == "delete")
                {
                    Console.WriteLine(current.delete(listCommande[1]));
                }

                if (listCommande[0] == "path")
                {
                    Console.WriteLine(current.getPath());
                }

                if (listCommande[0] == "ls")
                {
                    if (current.ls() != null)
                    {
                        Console.WriteLine("Liste des fichiers du répertoire courant :\n");
                        Console.WriteLine("Nom :       Permission :       Type :\n");

                        foreach (File f in current.ls())
                        {
                            Console.WriteLine(f.Name + "{0, 15}\t ({1:p1})", f.Permission, f.GetType());
                        }
                    }
                }

                if (listCommande[0] == "root")
                {
                    Console.WriteLine(current.getRoot());
                }

                if (listCommande[0] == "parent")
                {
                    
                    if (current == fileSystem)
                    {
                        Program.exit();
                    }

                    else
                    {
                        Console.WriteLine(current = current.getParent());
                    }
                }

                if (listCommande[0] == "file")
                {
                    Console.WriteLine(current.isFile());
                }

                if (listCommande[0] == "directory")
                {
                    Console.WriteLine(current.isDirectory());
                }

                if (listCommande[0] == "name")
                {
                    Console.WriteLine(current.getName());
                }

                if (listCommande[0] == "chmod")
                {
                    current.chmod(listCommande[1]);
                }

                Console.WriteLine();
            }
        }

        // Petit Bonus
        public static void exit()
        {
            Console.Write("Voulez vous vraiment quitter ? (O/N) : ");
            string answer = Console.ReadLine();
            if (answer == "O" || answer == "o" || answer == "Oui" || answer == "OUI" || answer == "oui" || answer == "OUi" || answer == "OuI" || answer == "oUI" || answer == "oUi" || answer == "ouI")
            {
                Environment.Exit(0);
            }
        }
    }
}
