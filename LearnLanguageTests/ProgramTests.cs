using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnLanguage.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            LanguageTeacher teacher1 = new LanguageTeacher();
            LanguageTeacher teacher2 = new LanguageTeacher();

            LanguageStudent student1 = new LanguageStudent();
            LanguageStudent student2 = new LanguageStudent();

            teacher1.AddLanguage("English");
            // Normal Process
            Assert.IsTrue(teacher1.Teach(student1, "English"));

            // Student can not AddLanguage by self
            student2.AddLanguage("English");
            Assert.IsFalse(student2.Languages.Count > 0);

            // Teacher can not Teach other Teacher
            Assert.IsFalse(teacher1.Teach(teacher2, "English"));

            // Teacher can not Teach not knew Language
            Assert.IsFalse(teacher1.Teach(student1, "French"));
        }
    }
}