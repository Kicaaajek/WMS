using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using WMS.Domain;
using WMS.Domain.Entity;

namespace WMS.App.Concrete
{
    public class UserService : BaseService<User>
    {
        private readonly string path = @"C:\Users\zajce\Desktop\pracainżynierska\KursDotNEtaMagazyn\Warehouse\WMS\Categories.csv";

        public UserService()
        {
            Items = Load("Users", path);
        }

        public void AddNewUser(int id, string name)
        {
            var user = new User(id, name);
            Items.Add(user);
            Update(user,user.UserName,path);
        }
        public bool ExistedId(int id)
        {
            bool existId = Items.Exists(u => u.Id == id);
            return existId;
        }
        public bool ExistedName(string name)
        {
            bool exist = Items.Exists(u => u.UserName == name);
            return exist;
        }
        public bool Empty()
        {
            bool isEmpty = Items.Any();
            return isEmpty;
        }
        /*
        public List<User> Load()
        {
            string fileName=@"Users.csv";
            using var sr = new StreamReader(fileName);
            using var csvReader = new CsvReader(sr,CultureInfo.InvariantCulture);
            csvReader.Configuration.RegisterClassMap<UserMap>();
            var records = csvReader.GetRecords<User>().ToList();
            return records;
        }
        public void Update(IEnumerable<User> users)
        {
            using FileStream fs = File.Open(@"Users.csv",FileMode.OpenOrCreate);
            using var writer = new StreamWriter(fs);
            using var csvWriter = new CsvWriter(writer,CultureInfo.InvariantCulture);
            //CsvSerializer serializer = new CsvSerializer(typeof(User);
            csvWriter.Configuration.RegisterClassMap<UserMap>();
            csvWriter.WriteRecords(users);
        }*/
    }
}
