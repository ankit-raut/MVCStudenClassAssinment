namespace MVCStudenClassAssinment.DAL.Migrations
{
    using MVCStudenClassAssinment.Model;
    using MVCStudenClassAssinment.Model.Model;

    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCStudenClassAssinment.DAL.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCStudenClassAssinment.DAL.ApplicationDBContext context)
        {
            IList<User> users = new List<User>();
            users.Add(new User() { Active = true, Email = "Ankit.Raut@gmail.com", FirstName = "Ankit", LastName = "Raut", Phone = "1234567890", UserType = UserTypes.Parent });
            users.Add(new User() { Active = true, Email = "Ankit.Raut1@gmail.com", FirstName = "Ankit1", LastName = "Raut", Phone = "1234567890", UserType = UserTypes.Student });
            users.Add(new User() { Active = true, Email = "Ankit.Raut2@gmail.com", FirstName = "Ankit2", LastName = "Raut", Phone = "1234567890", UserType = UserTypes.Student });
            users.Add(new User() { Active = true, Email = "Ankit.Raut3@gmail.com", FirstName = "Ankit3", LastName = "Raut", Phone = "1234567890", UserType = UserTypes.Student });
            context.Users.AddRange(users);

            IList<SchoolClass> schoolClass = new List<SchoolClass>();
            schoolClass.Add(new SchoolClass() { Name = "Class 1" });
            schoolClass.Add(new SchoolClass() { Name = "Class 2" });
            schoolClass.Add(new SchoolClass() { Name = "Class 3" });
            schoolClass.Add(new SchoolClass() { Name = "Class 4" });
            context.SchoolClasss.AddRange(schoolClass);

            IList<StudentClass> studentClass = new List<StudentClass>();
            studentClass.Add(new StudentClass() { Class = schoolClass[0], Student = users[1] });
            studentClass.Add(new StudentClass() { Class = schoolClass[1], Student = users[2] });
            studentClass.Add(new StudentClass() { Class = schoolClass[2], Student = users[3] });
            context.SchoolClasss.AddRange(schoolClass);

            IList<ParentStudent> parentStudent = new List<ParentStudent>();
            parentStudent.Add(new ParentStudent() { Parent = users[0], Student = users[1] });
            parentStudent.Add(new ParentStudent() { Parent = users[0], Student = users[2] });
            parentStudent.Add(new ParentStudent() { Parent = users[0], Student = users[3] });
            context.SchoolClasss.AddRange(schoolClass);

            base.Seed(context);
        }
    }
}
