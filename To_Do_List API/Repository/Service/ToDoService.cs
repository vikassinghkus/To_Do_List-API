using System.Text.Json;
using To_Do_List_API.Model;
using To_Do_List_API.Repository.Interface;

namespace To_Do_List_API.Repository.Service
{
    public class ToDoService : IToDo
    {
        private readonly string _filePath = "Data/ToDoItems.json";
        private List<ToDoItems> _toDoItems;
        public ToDoService()
        {
            _toDoItems = LoadData();
        }
        private  List<ToDoItems> LoadData()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<ToDoItems>>(json) ?? new List<ToDoItems>();
            }
            return new List<ToDoItems>();
        }
        public void Add(ToDoItems item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItems> GetAll()
        {
            throw new NotImplementedException();
        }

        public ToDoItems? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void saveData()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ToDoItems updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}
