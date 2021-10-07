using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PSS_Visual.Models
{
    public class Cidade
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(100, ErrorMessage = "{0} pode ter até {1} caracteres!")]
        [Required(ErrorMessage = "{0} deve ser informada!")]
        public string Descricao { get; set; }

        string uf { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "{0} deve ter {1} caracteres!")]
        [Required(ErrorMessage = "{0} deve ser informada!")]
        public string UF
        {
            get => uf;
            set => uf = value.ToUpper();
        }
    }
}
