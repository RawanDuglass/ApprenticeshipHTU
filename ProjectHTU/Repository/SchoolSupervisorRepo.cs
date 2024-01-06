using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectHTU.Data;
using ProjectHTU.Entities;

namespace ProjectHTU.Repository
{
    public class SchoolSupervisorRepo : ISchoolSupervisorRepo
    {
        ApplicationDbContext context;
        private readonly UserManager<Person> _userManager;

        public SchoolSupervisorRepo(ApplicationDbContext context, UserManager<Person> _userManager)
        {
            this.context = context;
            this._userManager = _userManager;
        }

        private SchoolSupervisor CreateUser()
        {
            try
            {
                return Activator.CreateInstance<SchoolSupervisor>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                    $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Ide" +
                    $"ntity/Pages/Account/Register.cshtml");
            }
        }

        public async Task CreateSchoolSupervisor(SchoolSupervisor schoolSupervisor, string password, string roleIds)
        {
            var user = CreateUser();

            user.Email = schoolSupervisor.Email;
            user.NormalizedEmail = schoolSupervisor.Email.ToUpper();
            user.UserName = schoolSupervisor.Email;
            user.NormalizedUserName = schoolSupervisor.Email.ToUpper();
            user.EmailConfirmed = true;
            user.firstName = schoolSupervisor.firstName;
            user.lastName = schoolSupervisor.lastName;
            user.secondName = schoolSupervisor.secondName;
            user.thiredName = schoolSupervisor.thiredName;
            user.schoolId = schoolSupervisor.schoolId;

            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = roleIds
            });

            var result = await _userManager.CreateAsync(user, password);
        }

        public async Task DeleteSchoolSupervisor(string Id)
        {
            var result = context.schoolSupervisors.Where(x => x.Id == Id).SingleOrDefault();
            context.schoolSupervisors.Remove(result);
            context.SaveChanges();
        }

        public List<SchoolSupervisor> GetAllSchoolSupervisors()
        {
            return context.schoolSupervisors.Include(x => x.school).ToList();
        }

        public async Task UpdateSchoolSupervisor(SchoolSupervisor schoolSupervisor)
        {
            var user = await _userManager.FindByIdAsync(schoolSupervisor.Id);
            if (user is SchoolSupervisor school)
            {
                // Update major property
                school.schoolId = schoolSupervisor.schoolId;
            }
            else
            {
                // Handle the case where the user is not of type StudentInfo
                Console.WriteLine("User is not a student");
            }

            user.Email = schoolSupervisor.Email;
            user.NormalizedEmail = schoolSupervisor.Email.ToUpper();
            user.NormalizedUserName = schoolSupervisor.Email.ToUpper();
            user.UserName = schoolSupervisor.Email;
            user.firstName = schoolSupervisor.firstName;
            user.secondName = schoolSupervisor.secondName;
            user.thiredName = schoolSupervisor.thiredName;
            user.lastName = schoolSupervisor.lastName;

            await _userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
