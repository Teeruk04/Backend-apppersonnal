using Backend.Models;

namespace Backend.DTOS.Addresss
{
    public class AddressResponse
    {
        static public object FormAddress(Address address)
        {
            return new
            {
                address.Id,
                address.address_startdate,
                address.address_enddate,
                address.address_housenumber,
                address.address_alley,
                address.address_road,
                address.address_canton,
                address.address_district,
                address.address_province,
                address.address_country,
                StatusAName = address.StatusA.Name,
                address.Createdate
            };
        }
    }
}
