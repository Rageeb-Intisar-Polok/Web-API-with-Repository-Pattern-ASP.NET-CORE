using DatabaseHandler.Models.NonEntityModels.VisibleUserTypesEntityModels;

namespace DatabaseHandler.Works.UserControllerWork.AddNewUserWork
{
    public interface IAddNewUser
    {
        public Task<string> AddStudent(VisibleStudent visibleStudent);
        public Task<string> AddTeacher(VisibleTeacher visibleTeacher);
        public Task<string> AddOfficial(VisibleOfficial visibleOfficial);
    }
}
