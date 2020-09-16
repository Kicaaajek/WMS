using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WMS.Domain.Entity;

namespace WMS.App.Concrete
{
    public class CategoryService: BaseService<Category>
    {
        private readonly string path = @"C:\Users\zajce\Desktop\pracainżynierska\KursDotNEtaMagazyn\Warehouse\WMS\WMS\bin\Debug\netcoreapp3.1\Categories.xml";
        public CategoryService()
        {
            Items = Load("Categories",path);
        }
        public bool Empty()
        {
            bool isEmpty = Items.Any();
            return isEmpty;
        }
        public bool Existed(string nameCat)
        {
            bool beExistCategory = Items.Exists(p => p.CategoryName == nameCat);
            return beExistCategory;
        }
        public int GetCatId(string nameCat)
        {
            int idCat=0;
            foreach (var c in Items)
            {
                if (c.CategoryName == nameCat)
                {
                    idCat = c.Id;
                }
            }
            return idCat;
        }
        public List<Category> GetAll()
        {
            var list = new List<Category>();
            foreach (var i in Items)
            {
                list.Add(i);
            }
            return list;
        }
        public void UpdateNewCategory(Category category)
        {
            AddNewItem(category, "Categories", path);
        }
        /*public List<Category> Load()
        {
            string path = @"C:\Users\zajce\Desktop\pracainżynierska\KursDotNEtaMagazyn\Warehouse\WMS\Categories.csv";
            var categories = new List<Category>();
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Items";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Category>), root);
            if (!File.Exists(path))
            {
                Items = new List<Category>();
            }
            
                string output = File.ReadAllText(path);
                StringReader stringReader = new StringReader(output);
                categories = (List<Category>)xmlSerializer.Deserialize(stringReader);
                return categories;
            
            /*var sr = new StreamReader(path);
            using var sr = File.Open(path, FileMode.Append);
            using var str = new StreamReader(sr);
            var csvReader = new CsvReader(str, CultureInfo.InvariantCulture);
            csvReader.Configuration.RegisterClassMap<CategoryMap>();
            var lists = csvReader.GetRecords<Category>().ToList();
            return lists;
        }
        public void Update(Category category)
        {
            using var stream = File.Open(@"Categories.csv", FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.HasHeaderRecord = false;
            csv.WriteRecords((IEnumerable<Category>)category);
        }*/
    }
}
