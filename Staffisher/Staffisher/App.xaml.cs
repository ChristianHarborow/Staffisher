using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Staffisher
{
    public partial class App : Application
    {
        public static Classes.Angler User { get; set; }
        public static string AnglersPath { get; private set; }
        public static List<Classes.Angler> Anglers { get; private set; }

        public App()
        {
            InitializeComponent();

            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            AnglersPath = Path.Combine(folderPath, "Anglers.json");

            Anglers = DeserializeList<Classes.Angler>(AnglersPath);
            if (Anglers.Count == 0) Anglers.Add(new Classes.Angler("christianharborow@email.com", GetHash("AdminPass"), "Chrisitan Harborow", true));

            MainPage = new NavigationPage(new Pages.LoginPage());
        }

        private List<T> DeserializeList<T>(string path)
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                List<T> list = JsonSerializer.Deserialize<List<T>>(jsonString);
                return list;
            }
            else
            {
                List<T> list = new List<T>();
                string jsonString = JsonSerializer.Serialize(list);
                File.WriteAllText(path, jsonString);
                return list;
            }
        }

        public static string GetHash(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(inputString)))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
