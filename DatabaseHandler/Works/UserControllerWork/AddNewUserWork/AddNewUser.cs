using DatabaseHandler.Context;
using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;
using DatabaseHandler.Repositories.EntityRepositories.DepartmentRepository;
using DatabaseHandler.Repositories.EntityRepositories.LevelTermRepository;
using DatabaseHandler.Repositories.EntityRepositories.RolesRepository;
using DatabaseHandler.Repositories.EntityRepositories.StudentRepository;
using DatabaseHandler.Repositories.EntityRepositories.TeacherRepository;
using DatabaseHandler.Repositories.EntityRepositories.UserRepository;

namespace DatabaseHandler.Works.UserControllerWork.AddNewUserWork
{
    public class AddNewUser : IAddNewUser
    {
        private readonly IOfficialRepository _officialRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILevelTermRepository _levelTermRepository;
        private readonly ApplicationDbContext _context;
        private readonly IRoleRepository _roleRepository;
        public AddNewUser(IOfficialRepository officialRepository,
            IStudentRepository studentRepository, ITeacherRepository teacherRepository,
            IUserRepository userRepository, ILevelTermRepository levelTermRepository,
            IDepartmentRepository departmentRepository, ApplicationDbContext context,
            IRoleRepository roleRepository)
        {
            _officialRepository= officialRepository;
            _studentRepository= studentRepository;
            _teacherRepository= teacherRepository;
            _userRepository= userRepository;
            _levelTermRepository= levelTermRepository;
            _departmentRepository= departmentRepository;
            _context= context;
            _roleRepository = roleRepository;
        }

        public async Task<string> AddStudent(VisibleStudent visibleStudent)
        {
            try
            {
                Users? ExistedUser = await _userRepository.GetById(visibleStudent.ID);
                if (ExistedUser != null)
                {
                    return "Id duplication error";
                }

                Users User = new Users()
                {
                    ID = visibleStudent.ID,
                    Name = visibleStudent.Name,
                    Email= visibleStudent.Email,
                    Phone= visibleStudent.Phone,
                    UserType = "Student"
                };

                await _userRepository.Add(User);
                
                Department? department = await _departmentRepository.GetDepartmentByName(visibleStudent.Department);
                if (department == null) {
                    return "Department not available.";
                }

                LevelTerm? levelTerm = await _levelTermRepository.GetLevelTermEntity(visibleStudent.Level, visibleStudent.Term);
                if (levelTerm == null) {
                    return "Level/Term is not available.";
                }

                Students student = new Students()
                {
                    LevelTermId = levelTerm.LevelTermId,
                    LevelTerm = levelTerm,
                    DepartmentId = department.DepartmentId,
                    Department = department,
                    IndividualId = User.IndividualID,
                    Individual = User
                };

                await _studentRepository.Add(student);
                await _context.SaveChangesAsync();
                return "Student added Successfully.";
            }
            catch (Exception ex)
            {
                await _context.DisposeAsync();
                return ex.Message;
            }
        }

        public async Task<string> AddTeacher(VisibleTeacher visibleTeacher)
        {
            try
            {
                Users? ExistedUser = await _userRepository.GetById(visibleTeacher.ID);
                if (ExistedUser != null)
                {
                    return "Id duplication error";
                }

                Users User = new Users()
                {
                    ID = visibleTeacher.ID,
                    Name = visibleTeacher.Name,
                    Email = visibleTeacher.Email,
                    Phone = visibleTeacher.Phone,
                    UserType = "Teacher"
                };

                await _userRepository.Add(User);

                Department? department = await _departmentRepository.GetDepartmentByName(visibleTeacher.Department);
                if (department == null)
                {
                    return "Department not available.";
                }

                Teachers teacher = new Teachers()
                {
                    IndividualId = User.IndividualID,
                    Individual = User,
                    DepartmentId = department.DepartmentId,
                    Department = department,
                    Designation = visibleTeacher.Designation
                };

                await _teacherRepository.Add(teacher);
                await _context.SaveChangesAsync();
                return "Teacher added successfully";
            }
            catch(Exception ex)
            {
                await _context.DisposeAsync();
                return ex.Message;
            }
        }
        public async Task<string> AddOfficial(VisibleOfficial visibleOfficial)
        {
            try
            {
                Users? ExistedUser = await _userRepository.GetById(visibleOfficial.ID);
                if (ExistedUser != null)
                {
                    return "Id duplication error";
                }

                Users User = new Users()
                {
                    ID = visibleOfficial.ID,
                    Name = visibleOfficial.Name,
                    Email = visibleOfficial.Email,
                    Phone = visibleOfficial.Phone,
                    UserType = "Official"
                };

                await _userRepository.Add(User);

                Role? role = await _roleRepository.GetByName(visibleOfficial.Role);
                if (role == null)
                {
                    return "Role not found";
                }
                Officials official = new Officials()
                {
                    RoleId = role.Id,
                    Role = role,
                    IndividualId = User.IndividualID,
                    Individual = User
                };
                await _officialRepository.Add(official);
                await _context.SaveChangesAsync();
                return "Official added successfully";
            }
            catch(Exception ex)
            {
                await _context.DisposeAsync();
                return ex.Message;
            }
        }
    }
}
