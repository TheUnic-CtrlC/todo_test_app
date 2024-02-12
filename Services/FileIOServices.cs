using AnimeApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeApp.Services
{
    internal class FileIOServices
    {
        public readonly string PATH;
        public FileIOServices(string path)
        {
            PATH = path;    
        }
        public BindingList<ToDoModel> LoadData()
        {
            
            var fileExist = File.Exists(PATH);
            if (!fileExist) 
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using(var reader = File.OpenText(PATH)) 
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }

        }

        public void SaveData(object todoDataList) 
        {
            using(StreamWriter writer = File.CreateText(PATH)) 
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
