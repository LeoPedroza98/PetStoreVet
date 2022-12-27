using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.VeterinarioAPI.Models.Base;

namespace PetStore.VeterinarioAPI.Models.Entities
{
    public class Especialidade : IEntity
    {
        public Especialidade(long id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [MaxLength(60)] public string Nome { get; set; }


        [NotMapped] public static Especialidade Acupuntura => new Especialidade(1, "Acupuntura");
        [NotMapped] public static Especialidade Dermatologia => new Especialidade(2, "Dermatologia");
        [NotMapped] public static Especialidade Oncologia => new Especialidade(3, "Oncologia");
        [NotMapped] public static Especialidade Patologia => new Especialidade(4, "Patologia");
        [NotMapped] public static Especialidade MedicinaVeterináriaIntensiva => new Especialidade(5, "Medicina Veterinária Intensiva");
        [NotMapped] public static Especialidade CirurgiaVeterinaria => new Especialidade(6, "Cirurgia Veterinária");
        [NotMapped] public static Especialidade Anestesiologia  => new Especialidade(7, "Anestesiologia");
        [NotMapped] public static Especialidade Homeopatia => new Especialidade(8, "Homeopatia");
        [NotMapped] public static Especialidade Anestesia => new Especialidade(9, "Anestesia");
        [NotMapped] public static Especialidade OftalmologiaVeterinária => new Especialidade(10, "Oftalmologia Veterinária");
        
        public static Especialidade[] ObterDados()
        {
            return new Especialidade[]
            {
                Acupuntura,
                Dermatologia,
                Oncologia,
                Patologia,
                MedicinaVeterináriaIntensiva,
                CirurgiaVeterinaria,
                Anestesiologia,
                Homeopatia,
                Anestesia,
                OftalmologiaVeterinária
            };
        }

    }

}
