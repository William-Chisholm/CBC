namespace CBC.Models
{
    public class PackageList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public PackageList()
        {
            this.Id = 0;
            this.Name = "";
        }

        public PackageList(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
