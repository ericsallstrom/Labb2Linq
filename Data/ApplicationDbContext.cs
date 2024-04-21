using Labb2Linq.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labb2Linq.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassList> ClassLists { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            SeedData(builder);
        }

        private static void SeedData(ModelBuilder builder)
        {
            var students = new[]
            {
                new Student { StudentId = 1, StudentName = "Lisa Bengtsson", FkClassId = 1 },
                new Student { StudentId = 2, StudentName = "David Pettersson", FkClassId = 1 },
                new Student { StudentId = 3, StudentName = "Emma Gustafsson", FkClassId = 2 },
                new Student { StudentId = 4, StudentName = "Andreas Lindberg", FkClassId = 2 },
                new Student { StudentId = 5, StudentName = "Sofia Johansson", FkClassId = 3 },
                new Student { StudentId = 6, StudentName = "Oscar Persson", FkClassId = 3 },
                new Student { StudentId = 7, StudentName = "Emma Karlsson", FkClassId = 4 },
                new Student { StudentId = 8, StudentName = "Alexander Andersson", FkClassId = 4 }
            };

            var teachers = new[]
            {
                new Teacher { TeacherId = 1, TeacherName = "Reidar Nilsen" },
                new Teacher { TeacherId = 2, TeacherName = "Aldor Besher" },
                new Teacher { TeacherId = 3, TeacherName = "Erika Eriksson" },
                new Teacher { TeacherId = 4, TeacherName = "Maria Karlsson" },
                new Teacher { TeacherId = 5, TeacherName = "Tobias Landén" },
            };

            var courses = new[]
            {
                new Course { CourseId = 1, CourseName = "Programmering 1" },
                new Course { CourseId = 2, CourseName = "Programmering 2" },
                new Course { CourseId = 3, CourseName = "Infrastruktur 1" },
                new Course { CourseId = 4, CourseName = "Infrastruktur 2" }
            };

            var classes = new[]
            {
                new ClassList { ClassId = 1, ClassName = "NET23" },
                new ClassList { ClassId = 2, ClassName = "JAVA23" },
                new ClassList { ClassId = 3, ClassName = "ITSÄK23" },
                new ClassList { ClassId = 4, ClassName = "NE23" }
            };

            var courseTeachers = new[]
            {
                new CourseTeacher { CourseTeacherId = 1, FkCourseId = 1, FkTeacherId = 1 },
                new CourseTeacher { CourseTeacherId = 2, FkCourseId = 1, FkTeacherId = 2 },
                new CourseTeacher { CourseTeacherId = 3, FkCourseId = 2, FkTeacherId = 1 },
                new CourseTeacher { CourseTeacherId = 4, FkCourseId = 2, FkTeacherId = 2 },
                new CourseTeacher { CourseTeacherId = 5, FkCourseId = 3, FkTeacherId = 3 },
                new CourseTeacher { CourseTeacherId = 6, FkCourseId = 3, FkTeacherId = 4 },
                new CourseTeacher { CourseTeacherId = 7, FkCourseId = 4, FkTeacherId = 3 },
                new CourseTeacher { CourseTeacherId = 8, FkCourseId = 4, FkTeacherId = 4 }
            };

            var courseStudents = new[]
            {
                new StudentCourse { StudentCourseId = 1, FkStudentId = 1, FkCourseId = 1 },
                new StudentCourse { StudentCourseId = 2, FkStudentId = 2, FkCourseId = 1 },
                new StudentCourse { StudentCourseId = 3, FkStudentId = 3, FkCourseId = 1 },
                new StudentCourse { StudentCourseId = 4, FkStudentId = 4, FkCourseId = 1 },
                new StudentCourse { StudentCourseId = 5, FkStudentId = 5, FkCourseId = 3 },
                new StudentCourse { StudentCourseId = 6, FkStudentId = 6, FkCourseId = 3 },
                new StudentCourse { StudentCourseId = 7, FkStudentId = 7, FkCourseId = 3 },
                new StudentCourse { StudentCourseId = 8, FkStudentId = 8, FkCourseId = 3 },
                new StudentCourse { StudentCourseId = 9, FkStudentId = 1, FkCourseId = 2 },
                new StudentCourse { StudentCourseId = 10, FkStudentId = 2, FkCourseId = 2 },
                new StudentCourse { StudentCourseId = 11, FkStudentId = 3, FkCourseId = 2 },
                new StudentCourse { StudentCourseId = 12, FkStudentId = 4, FkCourseId = 2 },
                new StudentCourse { StudentCourseId = 13, FkStudentId = 5, FkCourseId = 4 },
                new StudentCourse { StudentCourseId = 14, FkStudentId = 6, FkCourseId = 4 },
                new StudentCourse { StudentCourseId = 15, FkStudentId = 7, FkCourseId = 4 },
                new StudentCourse { StudentCourseId = 16, FkStudentId = 8, FkCourseId = 4 }
};

            var enrollments = new[]
            {
                new Enrollment { EnrollmentId = 1, FkCourseId = 1, FkStudentId = 1 },
                new Enrollment { EnrollmentId = 2, FkCourseId = 1, FkStudentId = 2 },
                new Enrollment { EnrollmentId = 3, FkCourseId = 1, FkStudentId = 3 },
                new Enrollment { EnrollmentId = 4, FkCourseId = 1, FkStudentId = 4 },
                new Enrollment { EnrollmentId = 5, FkCourseId = 3, FkStudentId = 5 },
                new Enrollment { EnrollmentId = 6, FkCourseId = 3, FkStudentId = 6 },
                new Enrollment { EnrollmentId = 7, FkCourseId = 3, FkStudentId = 7 },
                new Enrollment { EnrollmentId = 8, FkCourseId = 3, FkStudentId = 8 },
                new Enrollment { EnrollmentId = 9, FkCourseId = 2, FkStudentId = 1 },
                new Enrollment { EnrollmentId = 10, FkCourseId = 2, FkStudentId = 2 },
                new Enrollment { EnrollmentId = 11, FkCourseId = 2, FkStudentId = 3 },
                new Enrollment { EnrollmentId = 12, FkCourseId = 2, FkStudentId = 4 },
                new Enrollment { EnrollmentId = 13, FkCourseId = 4, FkStudentId = 5 },
                new Enrollment { EnrollmentId = 14, FkCourseId = 4, FkStudentId = 6 },
                new Enrollment { EnrollmentId = 15, FkCourseId = 4, FkStudentId = 7 },
                new Enrollment { EnrollmentId = 16, FkCourseId = 4, FkStudentId = 8 },
            };

            builder.Entity<Student>().HasData(students);
            builder.Entity<Teacher>().HasData(teachers);
            builder.Entity<Course>().HasData(courses);
            builder.Entity<ClassList>().HasData(classes);
            builder.Entity<CourseTeacher>().HasData(courseTeachers);
            builder.Entity<StudentCourse>().HasData(courseStudents);
            builder.Entity<Enrollment>().HasData(enrollments);
        }
    }
}
