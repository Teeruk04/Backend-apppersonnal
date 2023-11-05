using Backend.Models;

namespace Backend.DTOS.FatherAndMothers
{
    public class FatherAndMotherResponse
    {
        static public object FromFatherAndMother(FatherAndMother fatherAndMothers)
        {
            return new
            {
                fatherAndMothers.Id,
                TitleName = fatherAndMothers.Title.Title_name,
                fatherAndMothers.fa_name,
                fatherAndMothers.fa_lastname,
                fatherAndMothers.fa_birthdate,
                fatherAndMothers.fa_placebirth,
                fatherAndMothers.fa_race,
                fatherAndMothers.fa_religion,
                fatherAndMothers.fa_nationality,
                fatherAndMothers.fa_address,
                fatherAndMothers.fa_phone,
                fatherAndMothers.fa_occupation,
                fatherAndMothers.fa_position,
                fatherAndMothers.fa_workplace,
                fatherAndMothers.fa_WPphone,
                TitleMName = fatherAndMothers.TitleM.Title,
                fatherAndMothers.mo_name,
                fatherAndMothers.mo_lastname,
                fatherAndMothers.mo_birthdate,
                fatherAndMothers.mo_placebirth,
                fatherAndMothers.mo_race,
                fatherAndMothers.mo_religion,
                fatherAndMothers.mo_nationality,
                fatherAndMothers.mo_address,
                fatherAndMothers.mo_phone,
                fatherAndMothers.mo_occupation,
                fatherAndMothers.mo_position,
                fatherAndMothers.mo_workplace,
                fatherAndMothers.mo_WPphone,
                fatherAndMothers.Createdate,
            };
        }
    }
}
