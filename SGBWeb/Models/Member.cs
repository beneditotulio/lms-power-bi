using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Members")]
    public class Member
    {
        [Key]
        [DisplayName("ID do Membro")]
        public string MemberID { get; set; }

        [DisplayName("Primeiro Nome")]
        public string FirstName { get; set; }

        [DisplayName("Outro Nome")]
        public string OtherName { get; set; }

        [DisplayName("Sobrenome")]
        public string LastName { get; set; }

        [DisplayName("Gênero")]
        public string Gender { get; set; }

        [DisplayName("Nacionalidade")]
        public string Nationality { get; set; }

        [DisplayName("Nuit")]
        public string Nuit { get; set; }

        [DisplayName("Tipo de Membro")]
        public string MemberType { get; set; }

        [DisplayName("Endereço")]
        public string Address { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DisplayName("Data de Criação")]
        public DateTime DateCreate { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }
    }

}