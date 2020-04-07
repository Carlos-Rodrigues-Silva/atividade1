using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Estacione.Models
{
    public class Estacionamento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome Estacionamento")]
        [Required]
        public string NomeEstacionamento { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Preço hora")]
        [Required]
        public double PrecoHora { get; set; }

        [Display(Name = "Avaliação")]
        [Required]
        public double Avaliacao { get; set; }

        [Display(Name = "Número vagas")]
        [Required]
        public int NumeroVagas { get; set; }

        [Display(Name = "Endereço")]
        [Required]
        public string NomeRua { get; set; }

        [Display(Name = "Número")]
        [Required]
        public string Numero { get; set; }

        [Display(Name = "CEP")]
        [Required]
        public string Cep { get; set; }

        [Display(Name = "Bairro")]
        [Required]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [Required]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [Required]
        public string Estado { get; set; }

        [Display(Name = "Logradouro")]
        [Required]
        public string TipoLogradouro { get; set; }

    }
}
