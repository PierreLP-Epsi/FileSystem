using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class File
    {
        public string Name;
        public int Permission;
        public Directory Parent;

        public File(string Name, Directory parent)
        {
            this.Name = Name;
            this.Parent = parent;
            this.Permission = 4;
        }

        public virtual bool isFile()
        {
            Console.WriteLine("Ceci est un fichier.");
            return true;
        }

        public virtual bool isDirectory()
        {
            Console.WriteLine("Ceci n'est pas un dossier.");
            return false;
        }

        public virtual bool mkdir(string name)
        {
            Console.WriteLine("C'est impossible, vous êtes sur un fichier.");
            return false;
        }

        public bool canRead()
        {
            return (Permission & 4) > 0;
        }

        public bool canWrite()
        {
            return (Permission & 2) > 0;
        }

        public bool canExecute()
        {
            return (Permission & 1) > 0;
        }

        public virtual bool createNewFile(string name)
        {
            Console.WriteLine("C'est impossible, vous êtes sur un fichier.");
            return false;
        }

        public virtual List<File> ls()
        {

            Console.WriteLine("C'est impossible, vous êtes sur un fichier.");
            return null;
        }

        public virtual File cd(string name)
        {
            return null;
        }

        public string getName()
        {
            return this.Name;
        }

        public string getPath()
        {
            Directory father = Parent;
            string path = Name;

            while (father != null)
            {
                
                path = father.Name + "\\" + path;
                father = father.Parent;
            }

            return path;
        }

        public virtual bool renameTo(string name, string newName)
        {
            return false;
        }

        public File getParent()
        {
            return Parent;
        }

        public string getRoot()
        {
            File father = Parent;
            string root = Name;

            while (father.Name != "FileSystem")
            {
                root = father.Name;
                father = father.Parent;
            }

            return root;
        }

        public virtual bool delete(string name)
        {
            return false;
        }

        public void chmod(string permission)
        {
            this.Permission = int.Parse(permission);
        }

        /*public List<File> search(string name)
        {

        }*/
    }
}