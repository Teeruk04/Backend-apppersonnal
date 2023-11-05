using Backend.Models;

namespace Backend.DTOS.Childs
{
    public class ChildResponse
    {
        static public object FromChild(Child child)
        {
            return new
            {
                child.Id,
                TitleName = child.Title.Title_name,
                child.Child_name,
                child.Child_lastname,
                child.Child_birthdate,
                child.Child_race,
                child.Child_nationlyty,
                child.Child_religion,
                child.Chaild_address,
                child.Child_occupation,
                child.Child_position,
                child.Child_workplace,
                child.Child_phone,
                child.Createdate,
            };
        }
    }
}
