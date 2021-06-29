using NUnit.Framework;
using System;
using System.Collections.Generic;
using Teleperformance_Backend_Test_NetCore;

namespace Teleperformance_Backend_Test_NetCore_Test
{
    public class Question2Tests
    {
        [SetUp]
        public void Setup()
        {
            // Do nothing
        }

        #region tests for Average of student
        [Test]
        public void CalculateAverageOfStudent_Student_Name_Is_Null()
        {
            Question2 q2 = new Question2();

            Assert.Throws(typeof(ArgumentNullException),
                () => { double r = q2[null]; });
        }

        [Test]
        public void CalculateAverageOfStudent_Student_Name_Is_Empty()
        {
            Question2 q2 = new Question2();

            Assert.Throws(typeof(ArgumentException),
                () => { double r = q2[string.Empty]; });
        }

        [Test]
        public void CalculateAverageOfStudent_Student_Not_Exists()
        {
            Question2 q2 = new Question2();

            Assert.Throws(typeof(ArgumentException),
                () => { double r = q2["Not Exists"]; });
        }

        [Test]
        public void CalculateAverageOfStudent_Student()
        {
            var grades = new Dictionary<string, double[]>()
            {
                { "Student A", new double[3] {100, 100, 100 } }
            };

            Question2 q2 = new Question2(grades);
            var average = q2["Student A"];
            Assert.AreEqual(100.00, average);

            grades.Add("Student B", new double[3] { 89.2, 100, 59 });
            q2 = new Question2(grades);
            average = q2["Student B"];
            Assert.AreEqual(82.73, average);

            grades.Add("Student C", new double[3] { 67.45, 12.8, 0 });
            q2 = new Question2(grades);
            average = q2["Student C"];
            Assert.AreEqual(26.75, average);
        }
        #endregion

        #region tests for average of student
        [Test]
        public void AverageOfCourse_Course_Is_Null()
        {
            var q2 = new Question2();
            Assert.Throws(typeof(ArgumentNullException),
                () => q2.AverageOfCourse(null));
        }

        [Test]
        public void AverageOfCourse_Course_Is_Empty()
        {
            var grades = new Dictionary<string, double[]>()
            {
                { "Student A", new double[3] {100, 100, 100 } }
            };
            var q2 = new Question2(grades);

            Assert.Throws(typeof(ArgumentNullException),
                () => q2.AverageOfCourse(string.Empty));
        }

        [Test]
        public void AverageOfCourse_Course_Is_Not_Exists()
        {
            var grades = new Dictionary<string, double[]>()
            {
                { "Student A", new double[3] {100, 100, 100 } }
            };
            var q2 = new Question2(grades);

            Assert.Throws(typeof(ArgumentException),
                () => q2.AverageOfCourse("Not exists"));
        }

        [Test]
        public void AverageOfCourse_Course_NoScores()
        {
            var q2 = new Question2();
            Assert.Throws(typeof(ApplicationException),
                () => q2.AverageOfCourse(Question2.COURSEA));
        }

        [Test]
        public void AverageOfCourse()
        {
            var grades = new Dictionary<string, double[]>()
            {
                { "Student A", new double[3] {100, 100, 100 } }
            };

            var q2 = new Question2(grades);
            var average = q2.AverageOfCourse(Question2.COURSEA);
            Assert.AreEqual(100.00, average);

            grades.Add("Student B", new double[3] { 89.2, 100, 59 });
            q2 = new Question2(grades);
            average = q2.AverageOfCourse(Question2.COURSEB);
            Assert.AreEqual(100.00, average);

            grades.Add("Student C", new double[3] { 67.45, 12.8, 0 });
            q2 = new Question2(grades);
            average = q2.AverageOfCourse(Question2.COURSEC);
            Assert.AreEqual(53.00, average);
        }
        #endregion

        #region tests for average of class
        public void AverageOfClass_NoScores()
        {
            var q2 = new Question2();
            Assert.Throws(typeof(ApplicationException), 
                () => q2.AverageOfClass());
        }

        [Test]
        public void AverageOfClass()
        {
            var grades = new Dictionary<string, double[]>()
            {
                { "Student A", new double[3] {100, 100, 100 } }
            };

            var q2 = new Question2(grades);
            var average = q2.AverageOfClass();
            Assert.AreEqual(100.00, average);

            grades.Add("Student B", new double[3] { 89.2, 100, 59 });
            q2 = new Question2(grades);
            average = q2.AverageOfClass();
            Assert.AreEqual(91.37, average);

            grades.Add("Student C", new double[3] { 67.45, 12.8, 0 });
            q2 = new Question2(grades);
            average = q2.AverageOfClass();
            Assert.AreEqual(69.83, average);
        }
        #endregion
    }
}