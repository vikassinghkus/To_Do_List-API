using To_Do_List_API.Model;

namespace To_Do_List_API.Repository.Interface
{
    public interface IToDo
    {
        public void saveData();
        public List<ToDoItems> GetAll();
        public ToDoItems? GetById(int id);
        public void Add(ToDoItems item);
        public void Update(int id, ToDoItems updatedItem);
        public void Delete(int id);
    }
}
