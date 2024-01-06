using ProjectHTU.Repository;
using ProjectHTU.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ProjectHTU.Entities

{
    public class TeamLeaderRepo : ITeamLeaderRepo
    {
        ApplicationDbContext context;
        private readonly UserManager<Person> _userManager;

        public TeamLeaderRepo(ApplicationDbContext context, UserManager<Person> userManager)
        {
            this.context = context;
            _userManager = userManager;
        }

        private TeamLeader CreateUser()
        {
            try
            {
                return Activator.CreateInstance<TeamLeader>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Person)}'. " +
                    $"Ensure that '{nameof(Person)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Ide" +
                    $"ntity/Pages/Account/Register.cshtml");
            }
        }
        public async Task CreateTeamLeader(TeamLeader teamLeader, string password, string roleIds)
        {
            var user = CreateUser();

            user.Email = teamLeader.Email;
            user.NormalizedEmail = teamLeader.Email.ToUpper();
            user.UserName = teamLeader.Email;
            user.NormalizedUserName = teamLeader.Email.ToUpper();
            user.EmailConfirmed = true;
            user.firstName = teamLeader.firstName;
            user.lastName = teamLeader.lastName;
            user.secondName = teamLeader.secondName;
            user.thiredName = teamLeader.thiredName;
            user.companyId = teamLeader.companyId; ;
            //user.dateOfBirth = student.dateOfBirth;
            context.UserRoles.Add(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = roleIds
            });
            var result = await _userManager.CreateAsync(user, password);
        }

        public async Task DeleteTeamLeader(string Id)
        {
            var c = context.teamLeaders.Where(x => x.Id == Id).FirstOrDefault();
            context.teamLeaders.Remove(c);
            context.SaveChanges();
        }

        public List<TeamLeader> GetAllTeamLeaders()
        {
            return context.teamLeaders.Include(x => x.company).ToList();
        }

        public async Task UpdateTeamLeader(TeamLeader teamLeader)
        {

            var user = await _userManager.FindByIdAsync(teamLeader.Id);
            if (user is TeamLeader teamLeader1)
            {
                // Update major property
                teamLeader1.companyId = teamLeader.companyId;
            }
            else
            {
                // Handle the case where the user is not of type StudentInfo
                Console.WriteLine("User is not a student");
                return;
            }

            user.Email = teamLeader.Email;
            user.NormalizedEmail = teamLeader.Email.ToUpper();
            user.NormalizedUserName = teamLeader.Email.ToUpper();
            user.UserName = teamLeader.Email;
            user.firstName = teamLeader.firstName;
            user.secondName = teamLeader.secondName;
            user.thiredName = teamLeader.thiredName;
            user.lastName = teamLeader.lastName;

            await _userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }
    }
}

