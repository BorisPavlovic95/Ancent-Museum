namespace API.Dtos
{
    public class UserWithAddressDto : UserDto
    {
        public AddressDto Address { get; set; }
    }
}
