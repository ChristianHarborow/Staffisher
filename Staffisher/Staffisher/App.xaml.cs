using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Staffisher.Classes;

namespace Staffisher
{
    public partial class App : Application
    {
        public static Angler User { get; set; }
        
        private static string AnglersPath { get; set; }
        private static string FutureMatchesPath { get; set; }
        private static string CurrentMatchPath { get; set; }
        private static string PastMatchesPath { get; set; }

        public static List<Angler> Anglers { get; private set; }
        public static List<FutureMatch> FutureMatches { get; private set; }
        public static CurrentMatch CurrentMatch { get; set; }
        public static List<PastMatch> PastMatches { get; private set; }

        public App()
        {
            InitializeComponent();

            /* In the final version of the application data will be retrieved from a database when required
             * Currently all data is being stored at all times on the device
             * This is just for demonstration purposes and will not occur in the final version
             */

            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            AnglersPath = Path.Combine(folderPath, "Anglers.json");
            FutureMatchesPath = Path.Combine(folderPath, "FutureMatches.json");
            CurrentMatchPath = Path.Combine(folderPath, "CurrentMatch.json");
            PastMatchesPath = Path.Combine(folderPath, "PastMatches.json");

            Anglers = DeserializeList<Angler>(AnglersPath);
            if (Anglers.Count == 0) Anglers.Add(new Angler("christianharborow@email.com", GetHash("AdminPass"), "Chrisitan Harborow", true));
            FutureMatches = DeserializeList<FutureMatch>(FutureMatchesPath);
            CurrentMatch = DeserializeObject<CurrentMatch>(CurrentMatchPath);
            PastMatches = DeserializeList<PastMatch>(PastMatchesPath);

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
                SerializeList<T>(list, path);
                return list;
            }
        }

        private T DeserializeObject<T>(string path)
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                T obj = JsonSerializer.Deserialize<T>(jsonString);
                return obj;
            }
            else
            {
                T obj = default(T);
                SerializeObject<T>(obj, path);
                return obj;
            }
        }

        private static void SerializeList<T>(List<T> list, string path)
        {
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(path, jsonString);
        }

        private static void SerializeObject<T>(T obj, string path)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(path, jsonString);
        }

        public static void SerializeAnglers() { SerializeList<Angler>(Anglers, AnglersPath); }
        public static void SerializeFutureMatches() { SerializeList<FutureMatch>(FutureMatches, FutureMatchesPath); }
        public static void SerializeCurrentMatch() { SerializeObject<CurrentMatch>(CurrentMatch, CurrentMatchPath); }
        public static void SerializePastMatches() { SerializeList<PastMatch>(PastMatches, PastMatchesPath); }

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
