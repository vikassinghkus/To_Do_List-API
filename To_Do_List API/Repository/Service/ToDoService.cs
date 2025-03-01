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
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
            }
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                if(jsonData != string.Empty)
                {
                    return JsonSerializer.Deserialize<List<ToDoItems>>(jsonData) ?? new List<ToDoItems>();
                }
            }
            return new List<ToDoItems>();
        }
        public void Add(ToDoItems item)
        {
            item.Id = _toDoItems.Any() ? _toDoItems.Max(t => t.Id) + 1 : 1;
            _toDoItems.Add(item);
            saveData();
        }

        public void Delete(int id)
        {
            _toDoItems.RemoveAll(x => x.Id == id);
            saveData();
        }

        public List<ToDoItems> GetAll() => _toDoItems;


        public ToDoItems? GetById(int id)
        {
            return _toDoItems.FirstOrDefault(x => x.Id == id);
        }

        public void saveData()
        {
            var jsonSerilizer = JsonSerializer.Serialize(_toDoItems);
            File.WriteAllText(_filePath, jsonSerilizer);
        }

        public void Update(int id, ToDoItems updatedItem)
        {
            var item = _toDoItems.FirstOrDefault(x=>x.Id == id);
            if(item != null)
            {
                item.Title = updatedItem.Title;
                item.Description = updatedItem.Description;
                item.isCompleted = updatedItem.isCompleted;
                saveData();
            }
        }
    }
}
