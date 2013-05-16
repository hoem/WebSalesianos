using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAlicanTeam.EN;
using System.Collections.Generic;

namespace TestCAD
{
    [TestClass]
    public class ENOptionalSubjectTest
    {
        [TestMethod]
        public void OptionalSubjectConnectingAndReadingAll()
        {
            var actual = new List<ENSubject>();
            var optionalSubject = new ENOptionalSubject();
            Assert.AreEqual(0, optionalSubject.Id);
            actual = optionalSubject.ReadAll();
        }

        [TestMethod]
        public void OptionalSubjectInsert()
        {
            var optionalSubject = new ENOptionalSubject();
            var subject = new ENSubject();

            var course = new ENCourse();
            //subject.Name = "nameTest";
            //subject.Course = course.Read(1);

            optionalSubject.Name = "nameTest";
            optionalSubject.Course = course.Read(1);

            optionalSubject.Save();

            var subjects = optionalSubject.ReadAll();
            var actual = subjects[subjects.Count - 1];
            actual.Delete();
            Assert.AreEqual("nameTest", actual.Name);
        }

        [TestMethod]
        public void OptionalSubjectUpdate()
        {
            var optionalSubject = new ENOptionalSubject().Read(1);
            var oldName = optionalSubject.Name;
            optionalSubject.Name = "testUpdateName";
            optionalSubject.Save();
            var actual = optionalSubject.Read(1);
            var actualName = optionalSubject.Name;
            actual.Name = oldName;
            actual.Save();
            Assert.AreEqual("testUpdateName", actualName);
        }

    }
}
