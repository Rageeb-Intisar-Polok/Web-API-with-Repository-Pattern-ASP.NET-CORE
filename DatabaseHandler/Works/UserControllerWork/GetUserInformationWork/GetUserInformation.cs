using DatabaseHandler.Models.EntityModels;
using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;
using DatabaseHandler.Repositories.EntityRepositories.DepartmentRepository;
using DatabaseHandler.Repositories.EntityRepositories.LevelTermRepository;
using DatabaseHandler.Repositories.EntityRepositories.RolesRepository;
using DatabaseHandler.Repositories.EntityRepositories.StudentRepository;
using DatabaseHandler.Repositories.EntityRepositories.TeacherRepository;
using DatabaseHandler.Repositories.EntityRepositories.UserRepository;

namespace DatabaseHandler.Works.UserControllerWork.GetUserInformationWork
{
    public class GetUserInformation : IGetUserInformation
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IOfficialRepository _officialRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILevelTermRepository _levelTermRepository;
        private readonly IRoleRepository _roleRepository;
        public GetUserInformation(IUserRepository userRepository,
            IStudentRepository studentRepository, IOfficialRepository officialRepository,
            IDepartmentRepository departmentRepository, ITeacherRepository teacherRepository,
            ILevelTermRepository levelTermRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _officialRepository = officialRepository;
            _departmentRepository = departmentRepository;
            _teacherRepository = teacherRepository;
            _levelTermRepository = levelTermRepository;
            _roleRepository = roleRepository;
        }
        public async Task<object> AboutUser(string id)
        {
            try
            {
                Users? user = await _userRepository.GetById(id);
                if (user == null)
                {
                    return "Not avaiable.";
                }
                string type = user.UserType;
                if(type == "Teacher")
                {
                    var details = await TeacherInformation(user);
                    return details;
                }
                else if(type == "Student")
                {
                    var details = await StudentInformation(user);
                    return details;
                }
                else if(type == "Official")
                {
                    Officials? official = await _officialRepository.GetOfficialByUniqueId(user.IndividualID);
                    if (official == null)
                    {
                        return "Unexpected behaviour : assigned in 'Users' but not in 'Officials'.";
                    }
                    return official;
                }
                else
                {
                    return "Unexpected behaviour : assigned in 'Users' but not in any other user type";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<object> TeacherInformation(Users user)
        {
            try
            {
                Teachers? teacher = await _teacherRepository.GetTeacherByUniqueId(user.IndividualID);
                if (teacher == null)
                {
                    return "Unexpected behaviour : assigned in 'Users' but not in 'Teacher'.";
                }

                Department? department = await _departmentRepository.GetDepartmentById(teacher.DepartmentId);

                if (department == null)
                {
                    return "Unexpected behaviour : Department is not initialized in 'Teachers'.";
                }

                VisibleTeacher visibleTeacher = new VisibleTeacher()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,


                    Department = department.DepartmentName,
                    Designation = teacher.Designation
                };

                return teacher;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<object> OfficialInformation(Users user)
        {
            try
            {
                Officials? Official = await _officialRepository.GetOfficialByUniqueId(user.IndividualID);
                if (Official == null)
                {
                    return "Unexpected behaviour : assigned in 'Users' but not in 'Officials'.";
                }


                Role? role = await _roleRepository.GetRoleId(Official.RoleId);

                if (role == null)
                {
                    return "Unexpected behaviour : Role is not initialized in 'Officials'.";
                }

                VisibleOfficial visibleOfficial = new VisibleOfficial()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,

                    Role = role.RoleName
                };
                return visibleOfficial;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        private async Task<object> StudentInformation(Users user)
        {
            try
            {
                Students? student = await _studentRepository.GetStudentByUniqueId(user.IndividualID);
                if (student == null)
                {
                    return "Unexpected behaviour : assigned in 'Users' but not in 'Students'.";
                }


                Department? department = await _departmentRepository.GetDepartmentById(student.DepartmentId);

                if (department == null)
                {
                    return "Unexpected behaviour : Department is not initialized in 'Student'.";
                }

                LevelTerm? levelTerm = await _levelTermRepository.GetLevelTermById(student.LevelTermId);
                if (levelTerm == null)
                {
                    return "Unexpected behaviour : Level/term is/are not initialized in 'Students'.";
                }

                VisibleStudent visibleStudent = new VisibleStudent()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,


                    Department = department.DepartmentName,
                    Level = levelTerm.Level,
                    Term = levelTerm.Term

                };

                return student;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
