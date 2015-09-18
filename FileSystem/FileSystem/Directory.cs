using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Directory : File
    {
        List <File> files = new List <File>();
        List<File> contenu = new List<File>();

        public Directory (string Name, Directory parent) : base (Name, parent)
        {
            Permission = 7;
        }

        public override bool isFile()
        {
            Console.WriteLine("Ceci n'est pas un fichier.");
            return false;
        }

        public override bool isDirectory()
        {
            Console.WriteLine("Ceci est un dossier.");
            return true;
        }

        public override bool mkdir(string name)
        {
            bool create = false;

            for (int i = 0; i < files.Count() && create == false; i++)
            {
                create = name == files[i].Name;
            }

            if (this.canWrite() && create == false)
            {
                files.Add(new Directory(name, this));
                return true;
            }

            else return false;
        }

        public override bool createNewFile(string name)
        {
            bool create = false;

            for (int i = 0; i < files.Count() && create == false; i++)
            {
                create = name == files[i].Name;
            }

            if (this.canWrite() && create == false)
            {
                files.Add(new File(name, this));
                return true;
            }
            return false;
        }

        public override List<File> ls()
        {
            return this.files;
        }

        public override File cd(string name)
        {
            File newCurrent = null;
            bool swap = false;

            for (int i = 0; swap == false && i < files.Count(); i++)
            {
                if (files[i].Name == name && files[i].canRead() && swap == false)
                {
                    newCurrent = files[i];
                    swap = true;
                }
            }

            return newCurrent;
        }

        public override bool renameTo(string name, string newName)
        {
            bool existingFile = false;
            int i = 0;

            while (i < files.Count() && existingFile == false)
            {
                existingFile = name == files[i].Name;
                i++;
            }

            if (this.canWrite() && existingFile == true)
            {
                existingFile = false;

                for (int ii = 0; ii < files.Count() && existingFile == false; ii++)
                {
                    existingFile = newName == files[ii].Name;
                }

                if (this.canWrite() && existingFile == false)
                {
                    files[i - 1].Name = newName;
                    return true;
                }
            }

            return false;
        }

        public override bool delete(string name)
        {
            int i = 0;
            bool existingFile = false;

            while (i < files.Count() && existingFile == false)
            {
                existingFile = name == files[i].Name;
                i++;
            }

            if (this.canWrite() && existingFile == true)
            {
                files.Remove(files[i - 1]);
                return true;
            }

            return false;
        }
    }
}