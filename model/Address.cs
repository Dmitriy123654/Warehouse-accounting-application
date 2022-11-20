namespace WarehouseInformationSystem.Model
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указан адрес")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="Недопустимая длина адреса")] 
        public string Name { get; set; }
        public Address(string name)
        {
            Name = name;
        }
        //связи
        public List<Location> Locations { get; set; } = new();
       
        public override string ToString()
        {
            return $"Адрес: {Name} \n";
        }
    }
}
