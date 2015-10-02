using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem;

namespace TestFileSystem
{
    [TestClass]
    public class UnitTest1
    {
        public Directory fileSystem;
        public Directory dossier;
        public Directory autreDossier;
        public File fichier;
        public File current;
        public Program programme;

        [TestInitialize]
        public void SetUp()
        {
            fileSystem = new Directory("FileSystem", null);
            fileSystem.mkdir("dossier");
            fileSystem.mkdir("autreDossier");
            fileSystem.createNewFile("fichier");
            current = fileSystem;
        }

        [TestMethod]
        public void mkdir()
        {
            Assert.IsTrue(fileSystem.mkdir("TestMkdir"));
        }

        [TestMethod]
        public void mkdirFalse()
        {
            //Dossier existant déjà
            Assert.IsFalse(fileSystem.mkdir("dossier"));
        }

        [TestMethod]
        public void mkdirFileFalse()
        {
            //mkdir sur un fichier
            current = (File)fileSystem.cd("fichier");
            Assert.IsFalse(current.mkdir("dossier"));
        }

        [TestMethod]
        public void mkdirDirectoryFalse()
        {
            //mkdir sur un dossier sans droit
            current = (Directory)fileSystem.cd("autreDossier");
            current.chmod("4");
            Assert.IsFalse(current.mkdir("dossier"));
        }

        [TestMethod]
        public void create()
        {
            Assert.IsTrue(fileSystem.createNewFile("TestCreate"));
        }

        [TestMethod]
        public void createFalse()
        {
            //Fichier existant déjà
            Assert.IsFalse(fileSystem.createNewFile("fichier"));
        }

        [TestMethod]
        public void createFileFalse()
        {
            //create sur un fichier
            current = (File)fileSystem.cd("fichier");
            Assert.IsFalse(current.createNewFile("fichier2"));
        }

        [TestMethod]
        public void createDirectoryFalse()
        {
            //create sur un fichier
            current = (Directory)fileSystem.cd("autreDossier");
            current.chmod("4");
            Assert.IsFalse(current.createNewFile("fichier2"));
        }

        [TestMethod]
        public void cdDirectory()
        {
            current = current.cd("dossier");
            Assert.AreEqual(current.Name, "dossier");
        }

        [TestMethod]
        public void cdFile()
        {
            current = current.cd("fichier");
            Assert.AreEqual(current.Name, "fichier");
        }

        [TestMethod]
        public void cdFalse()
        {
            current = current.cd("dossier");
            Assert.AreNotEqual(current.Name, "dosssier");
        }

        [TestMethod]
        public void ls()
        {
            Assert.AreEqual(fileSystem.ls().Count, 3);
        }

        [TestMethod]
        public void lsFalse()
        {
            Assert.AreNotEqual(fileSystem.ls().Count, 2);
        }

        [TestMethod]
        public void chmod()
        {
            current.chmod("4");
            Assert.AreEqual(current.Permission, 4);
        }

        [TestMethod]
        public void chmodFalse()
        {
            current.chmod("5");
            Assert.AreNotEqual(current.Permission, 4);
        }

        [TestMethod]
        public void rename()
        {
            Assert.IsTrue(fileSystem.renameTo("dossier", "dossierRename"));
            dossier = (Directory)fileSystem.cd("dossierRename");
            Assert.AreEqual(dossier.getName(), "dossierRename");
        }

        [TestMethod]
        public void renameFalse()
        {
            Assert.IsTrue(fileSystem.renameTo("dossier", "dossierRename"));
            dossier = (Directory)fileSystem.cd("dossierRename");
            Assert.AreNotEqual(dossier.getName(), "dosssierRename");
        }

        [TestMethod]
        public void delete()
        {
            Assert.IsTrue(fileSystem.delete("dossier"));
        }

        [TestMethod]
        public void deleteFalse()
        {
            Assert.IsFalse(fileSystem.delete("dosssier"));
        }

        [TestMethod]
        public void path()
        {
            current = fileSystem.cd("dossier");
            Assert.AreEqual(current.getPath(), "FileSystem\\dossier");
        }

        [TestMethod]
        public void pathFalse()
        {
            current = fileSystem.cd("dossier");
            Assert.AreNotEqual(current.getPath(), "FileSystem\\dosssier");
        }

        [TestMethod]
        public void root()
        {
            fileSystem = (Directory)fileSystem.cd("dossier");
            fileSystem.mkdir("do$$ier");
            fileSystem = (Directory)fileSystem.cd("do$$ier");
            Assert.AreEqual(fileSystem.getRoot(), "dossier");
        }

        [TestMethod]
        public void rootFalse()
        {
            fileSystem = (Directory)fileSystem.cd("dossier");
            fileSystem.mkdir("do$$ier");
            fileSystem = (Directory)fileSystem.cd("do$$ier");
            Assert.AreNotEqual(fileSystem.getRoot(), "dosssier");
        }

        [TestMethod]
        public void parent()
        {
            fileSystem = (Directory)fileSystem.cd("dossier");
            fileSystem.mkdir("do$$ier");
            fileSystem = (Directory)fileSystem.cd("do$$ier");
            Assert.AreEqual(fileSystem.getRoot(), "dossier");
        }

        [TestMethod]
        public void parentFalse()
        {
            fileSystem = (Directory)fileSystem.cd("dossier");
            fileSystem.mkdir("do$$ier");
            fileSystem = (Directory)fileSystem.cd("do$$ier");
            Assert.AreNotEqual(fileSystem.getRoot(), "dosssier");
        }

        [TestMethod]
        public void file()
        {
            current = (File)fileSystem.cd("fichier");
            Assert.IsTrue(current.isFile());
        }

        [TestMethod]
        public void fileDirectory()
        {
            dossier = (Directory)fileSystem.cd("dossier");
            Assert.IsFalse(dossier.isFile());
        }

        [TestMethod]
        public void directory()
        {
            dossier = (Directory)fileSystem.cd("dossier");
            Assert.IsTrue(dossier.isDirectory());
        }

        [TestMethod]
        public void directoryFile()
        {
            current = (File)fileSystem.cd("fichier");
            Assert.IsFalse(current.isDirectory());
        }

        [TestMethod]
        public void name()
        {
            Assert.AreEqual(fileSystem.getName(), "FileSystem");
        }

        [TestMethod]
        public void nameFalse()
        {
            Assert.AreNotEqual(fileSystem.getName(), "Filesystem");
        }
    }
}
