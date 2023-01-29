using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Models.NonEntityModels.CustomizingDetailsModels;
using DatabaseHandler.Repositories.EntityRepositories.LevelTermRepository;
using DatabaseHandler.Repositories.EntityRepositories.RolesRepository;

namespace DatabaseHandler.Works.InitializationControllerWork
{
    public class Initialization : IInitialization
    {
        private readonly ApplicationDbContext _Context;
        private readonly ILevelTermRepository _LevelTermRepository;
        private readonly IRoleRepository _RoleRepository;
        public Initialization(ApplicationDbContext context, ILevelTermRepository levelTermRepository, IRoleRepository roleRepository)
        {
            _Context = context;
            _LevelTermRepository = levelTermRepository;
            _RoleRepository = roleRepository;
        }

        public async Task<string> Initialize(InitializingModel Model)
        {
            try
            {
                int LevelCount = Model.LevelCount;
                SortedSet<string> Terms = Model.Terms;
                SortedSet<string> FoundRoles = Model.RolesOfOfficials;

                List<LevelTerm> LevelTerms = new();
                List<Role> Roles = new();



                for (int Level = 1; Level <= LevelCount; Level++)
                {
                    foreach(string Term in Terms)
                    {
                        LevelTerm LevelTerm = new()
                        {
                            Term = Term,
                            Level = Level
                        };
                        LevelTerms.Add(LevelTerm);
                    }
                }

                foreach(string role in FoundRoles)
                {
                    Role Role = new()
                    {
                        RoleName = role
                    };

                    Roles.Add(Role);
                }

                await _RoleRepository.AddSome(Roles);
                await _LevelTermRepository.AddSome(LevelTerms);


                await _Context.SaveChangesAsync();
                return "Complete";
            }
            catch (Exception Ex)
            {
                string Message = Ex.Message;
                await _Context.DisposeAsync();
                return Message;
            }
        }
        
    }
}
