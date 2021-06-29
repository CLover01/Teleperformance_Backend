using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance_Backend_Test_NetCore
{
    public class Question2
    {
        public const string STUDENTTEMPLATE = "Student {0}";
        public const string COURSEA = "COURSE A";
        public const string COURSEB = "COURSE B";
        public const string COURSEC = "COURSE C";
        public const int NUMBEROFSCORES = 3;

        /// <summary>
        /// Key - value for stored the grades of the classes.
        /// The key is the student name.
        /// Value are the student's grades.
        /// </summary>
        private Dictionary<string, double[]> _gradesOfClasses;

        public Question2() 
            : this(new Dictionary<string, double[]>())
        { }

        public Question2(Dictionary<string, double[]> gradesOfClasses)
        {
            if (gradesOfClasses == null) throw new ArgumentNullException(nameof(gradesOfClasses));
            _gradesOfClasses = gradesOfClasses;
        }

        /// <summary>
        /// Calculate Average scores of a student by the student name.
        /// </summary>
        /// <param name="studentName">The student name.</param>
        /// <returns>The average of the student.</returns>
        public double this[string studentName]
        {
            get
            {
                if (studentName == null) throw new ArgumentNullException(nameof(studentName));

                if (_gradesOfClasses.ContainsKey(studentName))
                {
                    return Math.Round(_gradesOfClasses[studentName].Sum() / NUMBEROFSCORES, 2);
                }

                throw new ArgumentException($"Student {studentName} does not exists.");
            }
        }

        /// <summary>
        /// Calculate the average scores of a course.
        /// </summary>
        /// <param name="course">
        /// The course name. Should be one of the values:
        ///     COURSE A, COURSE B, COURSE C
        /// </param>
        /// <returns>The average scores of the course.</returns>
        public double AverageOfCourse(string course)
        {
            if (string.IsNullOrEmpty(course)) throw new ArgumentNullException(nameof(course));
            if (_gradesOfClasses.Count == 0) throw new ApplicationException("No scores stored. Cannot calculate the average.");

            int index = 0;
            switch(course.ToUpper())
            {
                case COURSEA:
                    index = 0;
                    break;

                case COURSEB:
                    index = 1;
                    break;

                case COURSEC:
                    index = 2;
                    break;

                default:
                    throw new ArgumentException($"{course} is not exists. The value should be one of: {COURSEA}, {COURSEB} or {COURSEC}.");
            }

            double sum = 0;
            foreach (var pair in _gradesOfClasses)
            {
                sum += pair.Value[index];
            }

            return Math.Round(sum / _gradesOfClasses.Count, 2);
        }

        /// <summary>
        /// Calculate the average scores of the class.
        /// </summary>
        /// <returns>The average scores of the class.</returns>
        public double AverageOfClass()
        {
            if (_gradesOfClasses.Count == 0) throw new ApplicationException("No scores stored. Cannot calculate the average.");

            double sum = 0;
            foreach (var pair in _gradesOfClasses)
            {
                sum += pair.Value.Sum();
            }

            return Math.Round(sum / (NUMBEROFSCORES * _gradesOfClasses.Count), 2);
        }

        internal void Print()
        {
            if (_gradesOfClasses.Count == 0) Console.WriteLine("No data!");

            var scoreTemplate = "{0}, {1:0.00}, {2:0.00}, {3:0.00}, {4:0.00}";

            Console.WriteLine("Student Name, Course A, Course B, Course C, Average");
            foreach (var pair in _gradesOfClasses)
            {
                Console.WriteLine(scoreTemplate, 
                    pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], this[pair.Key]);
            }

            Console.WriteLine(string.Format("Average scores for Course A: {0:0.00}.", 
                AverageOfCourse(COURSEA)));
            Console.WriteLine(string.Format("Average scores for Course B: {0:0.00}.",
                AverageOfCourse(COURSEB)));
            Console.WriteLine(string.Format("Average scores for Course C: {0:0.00}.",
                AverageOfCourse(COURSEC)));
            Console.WriteLine(string.Format("Average scores for Class: {0:0.00}.",
                AverageOfClass()));
            Console.WriteLine();
        }
    }
}
