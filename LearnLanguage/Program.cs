using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnLanguage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LanguageTeacher teacher = new LanguageTeacher();
            teacher.AddLanguage("English");

            LanguageStudent student = new LanguageStudent();
            teacher.Teach(student, "English");
            teacher.Teach(student, "French");

            foreach (var language in student.Languages)
            {
                Console.WriteLine(language);
            }
        }
    }

    public class LanguageStudent
    {
        private List<string> languages = new List<string>();
        public List<string> Languages
        {
            get { return languages; }
            set { languages = value; }
        }

        public bool isStudent = false;
        public bool isTeach = false;

        public LanguageStudent()
        {
            isStudent = true;
            isTeach = false;
        }

        public void AddLanguage(string language)
        {
            if (!isStudent || isTeach)
            {
                var existLanguages = languages.Any(x => languages.Contains(language));
                if (!existLanguages)
                {
                    languages.Add(language);
                }
                isTeach = false;
            }
        }
    }

    public class LanguageTeacher : LanguageStudent
    {
        public LanguageTeacher()
        {
            isStudent = false;
        }

        public bool Teach(LanguageStudent student, string language)
        {
            if (!student.isStudent)
            {
                return false;
            }

            var teacherKnew = this.Languages.Any(x => x.Contains(language));
            if (!teacherKnew)
            {
                return false;
            }

            var studentKnew = student.Languages.Any(x => x.Contains(language));
            if (studentKnew)
            {
                return false;
            }

            student.isTeach = true;
            student.AddLanguage(language);
            return true;
        }
    }
}
