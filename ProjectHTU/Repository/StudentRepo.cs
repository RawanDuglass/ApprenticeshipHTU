using Microsoft.AspNetCore.Identity;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<Person> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StudentRepo(ApplicationDbContext context, UserManager<Person> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        private Student CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Student>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                    $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Ide" +
                    $"ntity/Pages/Account/Register.cshtml");
            }
        }

        public List<Student> GetAllstudents()
        {
            return context.students.ToList();
        }

        public async Task CreateStudent(Student student, string password, string roleIds)
        {
            var user = CreateUser();

            user.Email = student.Email;
            user.NormalizedEmail = student.Email.ToUpper();
            user.UserName = student.Email;
            user.NormalizedUserName = student.Email.ToUpper();
            user.EmailConfirmed = true;
            user.firstName = student.firstName;
            user.lastName = student.lastName;
            user.secondName = student.secondName;
            user.thiredName = student.thiredName;
            user.major = student.major;

            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = roleIds
            });

            var result = await _userManager.CreateAsync(user, password);
        }

        public async Task DeleteStudent(string Id)
        {
            var c = context.students.Where(x => x.Id == Id).SingleOrDefault();
            context.students.Remove(c);
            await context.SaveChangesAsync();

        }

        public async Task UpdateStudent(Student student)
        {
            var user = await _userManager.FindByIdAsync(student.Id);

            if (user is Student stu)
            {
                // Update major property
                stu.major = student.major;
            }
            else
            {
                // Handle the case where the user is not of type StudentInfo
                Console.WriteLine("User is not a student");
                return;
            }

            user.Email = student.Email;
            user.NormalizedEmail = student.Email.ToUpper();
            user.NormalizedUserName = student.Email.ToUpper();
            user.UserName = student.Email;
            user.firstName = student.firstName;
            user.secondName = student.secondName;
            user.thiredName = student.thiredName;
            user.lastName = student.lastName;


            await _userManager.UpdateAsync(user);

            await context.SaveChangesAsync();
        }
    }
}
