using Newtonsoft.Json;
using Solution_1_Work_12_Kuznetsov_IS_21_3.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1_Work_12_Kuznetsov_IS_21_3.Services
{
    internal class File_Input_Output
    {
        private readonly string PATH;

        public File_Input_Output(string path)
        {
            this.PATH = path;
        }

        public BindingList<Note> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists) {
                File.CreateText(PATH).Dispose();
                return new BindingList<Note>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Note>>(fileText);
            }
        }

        public void SaveData (object Notes)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(Notes);
                writer.Write(output);
            }
        }
    }
}
