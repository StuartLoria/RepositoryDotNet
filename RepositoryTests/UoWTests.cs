using CoursesLibrary;
using CoursesLibrary.Implementations;
using CoursesLibrary.Interfaces;
using CoursesLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryTests
{
    [TestClass]
    public class UoWTests
    {
        private IUnitOfWorkCourses unitOfWork;
        private CoursesDBContext context;
        private ICourseRepository coursesRepo;
        private IAuthorRepository authorsRepo;

        public UoWTests()
        {
            context = new CoursesDBContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Course course1 = new Course 
            {
                Id = 1,
                Name = "TYPESCRIPT: THE BIG PICTURE",
                Description = "Learn Typescript",
                SalesTimes = 1000,
                Authors = new List<Author> {
                    new Author
                    {
                        Id = 1,
                        Name = "Simon Allardice",
                        Language = "English"
                    }
                }
            };

            Course course2 = new Course
            {
                Id = 2,
                Name = "Angular Up and Running",
                Description = "Learn Angular",
                SalesTimes = 2000,
                Authors = new List<Author> {
                    new Author
                    {
                        Id = 2,
                        Name = "John Papa",
                        Language = "English"
                    }
                }
            };

            context.AddRange(course1, course2);
            context.SaveChanges();

            //var course1Found = context.Courses.Where(c => c.Id == 1).First();
            //course1Found.Authors.Add(new Author {
            //    Id = 1,
            //    Name = "Simon Allardice"
            //});

            //var course2Found = context.Courses.Where(c => c.Id == 2).First();
            //course2Found.Authors.Add(new Author
            //{
            //    Id = 2,
            //    Name = "John Papa"
            //});

            //context.SaveChanges();

            coursesRepo = new CourseRepository(context);
            authorsRepo = new AuthorRepository(context);
            unitOfWork = new UnitOfWorkCourses(context, coursesRepo, authorsRepo);
        }

        [TestMethod]
        public void CourseRepoGetById()
        {
            var foundCourses = coursesRepo.GetCoursesWithAuthors().ToList();
            Assert.IsNotNull(foundCourses);
            Assert.AreEqual(foundCourses.Count(), 2);
            Assert.AreEqual(foundCourses[0].Name, "TYPESCRIPT: THE BIG PICTURE");
            Assert.AreEqual(foundCourses[0].Authors.Count(), 1);
            Assert.AreEqual(foundCourses[0].Authors[0].Name, "Simon Allardice");
        }

        [TestMethod]
        public void CourseRepoGetTopSellingCourses()
        {
            var foundCourses = coursesRepo.GetTopSellingCourses().ToList();
            Assert.IsNotNull(foundCourses);
            Assert.AreEqual(foundCourses.Count(), 2);
            Assert.AreEqual(foundCourses[0].Name, "Angular Up and Running");
            Assert.AreEqual(foundCourses[0].Authors.Count(), 1);
            Assert.AreEqual(foundCourses[0].Authors[0].Name, "John Papa");
        }

        [TestMethod]
        public void UnitOfWork()
        {
            //var courses = unitOfWork.Courses.GetCoursesWithAuthors();
            
            var course = unitOfWork.Courses.Get(1);
            Assert.AreEqual(course.Authors[0].Language, "English");

            course.Authors[0].Language = "Spanish";
            unitOfWork.Complete();
            
            course = unitOfWork.Courses.Get(1);
            Assert.AreEqual(course.Authors[0].Language, "Spanish");
        }
    }
}
